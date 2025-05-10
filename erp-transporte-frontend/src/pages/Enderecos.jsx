import { useEffect, useState } from 'react';
import { Box, Button, Snackbar, Alert, TextField } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import EnderecoForm from '../components/EnderecoForm';
import { getEnderecosByCliente, createEndereco, updateEndereco, deleteEndereco } from '../services/enderecoService';


const Enderecos = ({ clienteId }) => {
  const [enderecos, setEnderecos] = useState([]);
  const [loading, setLoading] = useState(true);
  const [formVisivel, setFormVisivel] = useState(false);
  const [enderecoSelecionado, setEnderecoSelecionado] = useState(null);
  const [openMsg, setOpenMsg] = useState(false);
  const [mensagem, setMensagem] = useState('');
  const [filtro, setFiltro] = useState('');
  // const [confirmarExclusao, setConfirmarExclusao] = useState({ open: false, id: null });


  const carregarEnderecos = async () => {
    const data = await getEnderecosByCliente(clienteId);
    setEnderecos(data);
    setLoading(false);
  };

  useEffect(() => {
    carregarEnderecos();
  }, [clienteId]);

  const handleSalvar = async (endereco) => {
    if (endereco.id) {
      await updateEndereco(clienteId, endereco.id, endereco);
      setMensagem('Registro atualizado com sucesso!');
    } else {
      await createEndereco(clienteId, endereco);
      setMensagem('Registro salvo com sucesso!');
    }
    setOpenMsg(true);
    setFormVisivel(false);
    setEnderecoSelecionado(null);
    carregarEnderecos();
  };

  const handleEditar = (endereco) => {
    setEnderecoSelecionado(endereco);
    setFormVisivel(true);
  };

  const handleExcluir = async (id) => {
    if (window.confirm('Deseja realmente excluir este endereço?')) {
      await deleteEndereco(clienteId, id);
      setMensagem('Registro excluído com sucesso!');
      setOpenMsg(true);
      carregarEnderecos();
    }
  };

  const handleCancelar = () => {
    setFormVisivel(false);
    setEnderecoSelecionado(null);
  };

  return (
    <Box>
      {/* <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 2 }}> */}
      <Box sx={{ display: 'flex', gap: 2, mb: 2 }}>
        <TextField
          label="Filtrar por logradouro"
          value={filtro}
          onChange={(e) => setFiltro(e.target.value)}
        />

        <Button
          variant="contained"
          onClick={() => {
            setEnderecoSelecionado(null);
            setFormVisivel(true); // ou setOpenForm(true), depende do seu estado
          }}
        >
          Novo Endereço
        </Button>
      </Box>


      {formVisivel && (
        <EnderecoForm
          endereco={enderecoSelecionado}
          onSubmit={handleSalvar}
          onCancel={handleCancelar}
        />
      )}

      <Box sx={{ height: 300, width: '100%' }}>
        {!loading && (
          <DataGrid
            rows={enderecos.filter(e =>
              e.logradouro.toLowerCase().includes(filtro.toLowerCase())
            )}

            columns={[
              { field: 'id', headerName: 'ID', width: 90 },
              { field: 'logradouro', headerName: 'Logradouro', flex: 1 },
              { field: 'cidade', headerName: 'Cidade', flex: 1 },
              { field: 'estado', headerName: 'UF', width: 100 },
              {
                field: 'acoes',
                headerName: 'Ações',
                width: 200,
                sortable: false,
                renderCell: (params) => (
                  <>
                    <Button size="small" onClick={() => handleEditar(params.row)}>Editar</Button>
                    <Button size="small" color="error" onClick={() => handleExcluir(params.row.id)}>Excluir</Button>
                  </>
                )
              }
            ]}
            pageSize={5}
            rowsPerPageOptions={[5, 10, 20]}
            disableSelectionOnClick
            getRowId={(row) => row.id}
          />
        )}
      </Box>

      <Snackbar open={openMsg} autoHideDuration={3000} onClose={() => setOpenMsg(false)}>
        <Alert onClose={() => setOpenMsg(false)} severity="success" sx={{ width: '100%' }}>
          {mensagem}
        </Alert>
      </Snackbar>
    </Box>
  );
};

export default Enderecos;
