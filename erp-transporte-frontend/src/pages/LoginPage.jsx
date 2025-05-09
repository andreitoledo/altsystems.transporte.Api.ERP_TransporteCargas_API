import { useState } from 'react';
import { useAuth } from '../contexts/AuthContext';
import { useNavigate } from 'react-router-dom';


const LoginPage = () => {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const { login } = useAuth(); // 👈 pega do contexto
  const navigate = useNavigate();


  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      const response = await fetch('https://localhost:44351/api/Auth/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, senha })
      });

      const data = await response.json();

      if (!response.ok) {
        alert(data.mensagem || 'Falha no login');
        return;
      }

      localStorage.setItem('token', data.token);
      login({ email }); // atualiza contexto
      navigate('/dashboard');

    } catch (err) {
      console.error(err);
      alert('Erro de conexão com o servidor');
    }
  };

  return (
    <form onSubmit={handleLogin}>
      <input type="email" placeholder="E-mail" value={email} onChange={e => setEmail(e.target.value)} />
      <input type="password" placeholder="Senha" value={senha} onChange={e => setSenha(e.target.value)} />
      <button type="submit">Entrar</button>
    </form>
  );
};

export default LoginPage;
