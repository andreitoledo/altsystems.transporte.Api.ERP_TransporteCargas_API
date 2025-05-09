import { useEffect, useState } from 'react';
import { Box, Button, Snackbar, Alert, TextField, Typography } from '@mui/material';
import ClienteForm from '../components/ClienteForm';
import { getClientes, createCliente, updateCliente, deleteCliente } from '../services/clienteService';
import { useSnackbar } from 'notistack';
import { DataGrid } from '@mui/x-data-grid';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogContentText,
  DialogActions,
  Tooltip, 
  IconButton
} from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';

const Clientes = () => {
  const [clientes, setClientes] = useState([]);
  const [filtro, setFiltro] = useState('');
  const [openForm, setOpenForm] = useState(false);
  const [clienteSelecionado, setClienteSelecionado] = useState(null);
  const [mensagem, setMensagem] = useState('');
  const [openMsg, setOpenMsg] = useState(false);
  const { enqueueSnackbar } = useSnackbar();
  const [confirmarExclusao, setConfirmarExclusao] = useState({ open: false, id: null });


  const carregarClientes = async () => {
    const data = await getClientes();
    setClientes(data);
  };

  useEffect(() => {
    carregarClientes();
  }, []);

  const handleSalvar = async (cliente) => {
    if (cliente.id) {
      await updateCliente(cliente.id, cliente);
      enqueueSnackbar('Registro atualizado com sucesso!', { variant: 'success' });
    } else {
      await createCliente(cliente);
      enqueueSnackbar('Registro salvo com sucesso!', { variant: 'success' });
    }
    setOpenMsg(true);
    setOpenForm(false);
    setClienteSelecionado(null);
    carregarClientes();
  };

  const handleEditar = (cliente) => {
    setClienteSelecionado(cliente);
    setOpenForm(true);
  };

  const handleExcluir = (id) => {
    setConfirmarExclusao({ open: true, id });
  };


  const handleCancelar = () => {
    setOpenForm(false);
    setClienteSelecionado(null);
  };

  const clientesFiltrados = clientes.filter(c =>
    c.nome.toLowerCase().includes(filtro.toLowerCase())
  );

  return (
    <Box>
      <Typography variant="h4" sx={{ mb: 2 }}>Cadastro de Clientes</Typography>
      <Box sx={{ display: 'flex', gap: 2, mb: 2 }}>
        <TextField label="Filtrar por nome" value={filtro} onChange={(e) => setFiltro(e.target.value)} />
        <Button variant="contained" onClick={() => setOpenForm(true)}>Novo Cliente</Button>
      </Box>

      {openForm && (
        <ClienteForm
          cliente={clienteSelecionado}
          onSubmit={handleSalvar}
          onCancel={handleCancelar}
        />
      )}

      <Box sx={{ height: 500, width: '100%' }}>
        <DataGrid
          rows={clientesFiltrados}
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
                  {/* EDITAR EXCLUIR  */}
                  {/* <Button size="small" onClick={() => handleEditar(params.row)}>Editar</Button>
                  <Button size="small" color="error" onClick={() => handleExcluir(params.row.id)}>Excluir</Button> */}

                  <Tooltip title="Editar">
                    <IconButton onClick={() => handleEditar(params.row)}>
                      <EditIcon />
                    </IconButton>
                  </Tooltip>
                  <Tooltip title="Excluir">
                    <IconButton color="error" onClick={() => handleExcluir(params.row.id)}>
                      <DeleteIcon />
                    </IconButton>
                  </Tooltip>
                </>
              )
            }
          ]}
          pageSize={5}
          rowsPerPageOptions={[5, 10, 20]}
          disableSelectionOnClick
          getRowId={(row) => row.id}
        />

        <Dialog
          open={confirmarExclusao.open}
          onClose={() => setConfirmarExclusao({ open: false, id: null })}
        >
          <DialogTitle>Confirmação</DialogTitle>
          <DialogContent>
            <DialogContentText>
              Deseja realmente excluir este cliente?
            </DialogContentText>
          </DialogContent>
          <DialogActions>
            <Button onClick={() => setConfirmarExclusao({ open: false, id: null })}>Cancelar</Button>
            <Button
              color="error"
              onClick={async () => {
                await deleteCliente(confirmarExclusao.id);
                setMensagem('Registro excluído com sucesso!');
                setOpenMsg(true);
                carregarClientes();
                setConfirmarExclusao({ open: false, id: null });
              }}
            >
              Excluir
            </Button>
          </DialogActions>
        </Dialog>

      </Box>

      <Snackbar open={openMsg} autoHideDuration={3000} onClose={() => setOpenMsg(false)}>
        <Alert onClose={() => setOpenMsg(false)} severity="success" sx={{ width: '100%' }}>
          {mensagem}
        </Alert>
      </Snackbar>
    </Box>
  );
};

export default Clientes;