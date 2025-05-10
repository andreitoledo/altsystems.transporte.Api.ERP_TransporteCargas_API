import { useEffect, useState } from 'react';
import { Box, Typography, TextField, Button, Snackbar, Alert } from '@mui/material';
import ContatoForm from '../components/ContatoForm';
import { getContatosByCliente, createContato, updateContato, deleteContato } from '../services/contatoService';
import { DataGrid } from '@mui/x-data-grid';
import { useSnackbar } from 'notistack';


const Contatos = ({ clienteId }) => {
  const [contatos, setContatos] = useState([]);
  const [filtro, setFiltro] = useState('');
  const [openForm, setOpenForm] = useState(false);
  const [contatoSelecionado, setContatoSelecionado] = useState(null);
  const { enqueueSnackbar } = useSnackbar();

  const carregarContatos = async () => {
    const data = await getContatosByCliente(clienteId);
    setContatos(data);
  };

  useEffect(() => {
    if (clienteId) carregarContatos();
  }, [clienteId]);

  const handleSalvar = async (contato) => {
    if (contato.id) {
      await updateContato(clienteId, contato.id, contato);
      enqueueSnackbar('Contato atualizado com sucesso!', { variant: 'success' });
    } else {
      await createContato(clienteId, contato);
      enqueueSnackbar('Contato salvo com sucesso!', { variant: 'success' });
    }
    setOpenForm(false);
    setContatoSelecionado(null);
    carregarContatos();
  };

  const handleEditar = (contato) => {
    setContatoSelecionado(contato);
    setOpenForm(true);
  };

  const handleExcluir = async (id) => {
    if (window.confirm('Deseja excluir este contato?')) {
      await deleteContato(clienteId, id);
      enqueueSnackbar('Contato excluído com sucesso!', { variant: 'success' });
      carregarContatos();
    }
  };

  const contatosFiltrados = contatos.filter(c =>
    c.nome.toLowerCase().includes(filtro.toLowerCase())
  );

  return (
    <Box>
      <Typography variant="h6">Contatos</Typography>
      <Box sx={{ display: 'flex', gap: 2, mb: 2 }}>
        <TextField label="Filtrar por nome" value={filtro} onChange={(e) => setFiltro(e.target.value)} />
        <Button variant="contained" onClick={() => setOpenForm(true)}>Novo Contato</Button>
      </Box>

      {openForm && (
        <ContatoForm
          contato={contatoSelecionado}
          onSubmit={handleSalvar}
          onCancel={() => {
            setOpenForm(false);
            setContatoSelecionado(null);
          }}
        />
      )}

      <Box sx={{ height: 400 }}>
        <DataGrid
          rows={contatosFiltrados}
          columns={[
            { field: 'id', headerName: 'ID', width: 90 },
            { field: 'nome', headerName: 'Nome', flex: 1 },
            { field: 'email', headerName: 'Email', flex: 1 },
            { field: 'telefone', headerName: 'Telefone', width: 150 },
            {
              field: 'acoes',
              headerName: 'Ações',
              sortable: false,
              width: 200,
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
      </Box>
    </Box>
  );
};

export default Contatos;