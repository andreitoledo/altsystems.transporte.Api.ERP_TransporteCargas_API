import { useEffect, useState } from 'react';
import { Box, Button, Dialog, DialogTitle, DialogContent, DialogActions, Snackbar, Alert } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import EnderecoForm from '../components/EnderecoForm';
import { getEnderecosByCliente, createEndereco, updateEndereco, deleteEndereco } from '../services/enderecoService';

const Enderecos = ({ clienteId }) => {
  const [enderecos, setEnderecos] = useState([]);
  const [loading, setLoading] = useState(true);
  const [openForm, setOpenForm] = useState(false);
  const [enderecoSelecionado, setEnderecoSelecionado] = useState(null);
  const [openMsg, setOpenMsg] = useState(false);
  const [mensagem, setMensagem] = useState('');
  const [confirmarExclusao, setConfirmarExclusao] = useState({ open: false, id: null });

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
      await updateEndereco(clienteId, endereco);
      setMensagem('Registro atualizado com sucesso!');
    } else {
      await createEndereco(clienteId, endereco);
      setMensagem('Registro salvo com sucesso!');
    }
    setOpenMsg(true);
    setOpenForm(false);
    setEnderecoSelecionado(null);
    carregarEnderecos();
  };

  const handleEditar = (endereco) => {
    setEnderecoSelecionado(endereco);
    setOpenForm(true);
  };

  const handleExcluir = (id) => {
    setConfirmarExclusao({ open: true, id });
  };

  const confirmarExcluir = async () => {
    await deleteEndereco(clienteId, confirmarExclusao.id);
    setMensagem('Registro excluído com sucesso!');
    setOpenMsg(true);
    carregarEnderecos();
    setConfirmarExclusao({ open: false, id: null });
  };

  const handleCancelar = () => {
    setOpenForm(false);
    setEnderecoSelecionado(null);
  };

  return (
    <Box>
      <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 1 }}>
        <Button variant="contained" onClick={() => { setOpenForm(true); setEnderecoSelecionado(null); }}>Novo Endereço</Button>
      </Box>
      <Box sx={{ height: 300, width: '100%' }}>
        {!loading && <DataGrid
          rows={enderecos}
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
        />}
      </Box>

      <Dialog open={openForm} onClose={handleCancelar}>
        <DialogTitle>{enderecoSelecionado ? 'Editar Endereço' : 'Novo Endereço'}</DialogTitle>
        <DialogContent>
          <EnderecoForm endereco={enderecoSelecionado} onSubmit={handleSalvar} onCancel={handleCancelar} />
        </DialogContent>
      </Dialog>

      <Dialog open={confirmarExclusao.open} onClose={() => setConfirmarExclusao({ open: false, id: null })}>
        <DialogTitle>Confirmação</DialogTitle>
        <DialogContent>Deseja realmente excluir este registro?</DialogContent>
        <DialogActions>
          <Button onClick={() => setConfirmarExclusao({ open: false, id: null })}>Cancelar</Button>
          <Button color="error" onClick={confirmarExcluir}>Excluir</Button>
        </DialogActions>
      </Dialog>

      <Snackbar open={openMsg} autoHideDuration={3000} onClose={() => setOpenMsg(false)}>
        <Alert onClose={() => setOpenMsg(false)} severity="success" sx={{ width: '100%' }}>
          {mensagem}
        </Alert>
      </Snackbar>
    </Box>
  );
};

export default Enderecos;