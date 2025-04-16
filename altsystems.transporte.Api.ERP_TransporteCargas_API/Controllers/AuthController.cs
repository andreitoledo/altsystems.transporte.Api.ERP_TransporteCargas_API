using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ERPContext _context;
        private readonly IConfiguration _config;

        public AuthController(ERPContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // inicio teste
        [HttpGet("teste-bcrypt")]
        public IActionResult TesteBCrypt()
        {
            var senhaOriginal = "admin123";
            var hash = BCrypt.Net.BCrypt.HashPassword(senhaOriginal);
            var validado = BCrypt.Net.BCrypt.Verify(senhaOriginal, hash);

            return Ok(new
            {
                senha = senhaOriginal,
                hash_gerado = hash,
                validado
            });
        }
        // fim teste

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var debug = new Dictionary<string, object?>
            {
                ["email_request"] = request.Email,
                ["senha_request"] = request.Senha
            };

            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email.ToLower().Trim() == request.Email.ToLower().Trim());

            debug["usuario_encontrado"] = usuario?.Email;
            debug["senha_hash_banco"] = usuario?.SenhaHash;

            if (usuario == null)
            {
                debug["status"] = "usuario_nao_encontrado";
                return Unauthorized(debug);
            }

            bool senhaValida = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash);
            debug["senha_valida"] = senhaValida;

            if (!senhaValida)
            {
                debug["status"] = "senha_invalida";
                return Unauthorized(debug);
            }

            debug["status"] = "autenticado_com_sucesso";

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, usuario.Nome),
        new Claim(ClaimTypes.Email, usuario.Email),
        new Claim(ClaimTypes.Role, usuario.Role)
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: creds
            );

            debug["token"] = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(debug); // resposta com o token + debug
        }

    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
