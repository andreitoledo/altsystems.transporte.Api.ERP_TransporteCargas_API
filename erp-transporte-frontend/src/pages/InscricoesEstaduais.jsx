import { useEffect, useState } from 'react';
import { Box, Button, Snackbar, Alert, TextField } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import InscricaoEstadualForm from '../components/InscricaoEstadualForm';
import {
  getInscricoesEstaduaisByCliente,
  createInscricaoEstadual,
  updateInscricaoEstadual,
  deleteInscricaoEstadual
} from '../services/inscricaoEstadualService';

const InscricoesEstaduais = ({ clienteId }) => {
  const [registros, setRegistros] = useState([]);
  const [filtrados, setFiltrados] = useState([]);
  const [formVisivel, setFormVisivel] = useState(false);
  const [itemSelecionado, setItemSelecionado] = useState(null);
  const [mensagem, setMensagem] = useState('');
  const [openMsg, setOpenMsg] = useState(false);
  const [filtro, setFiltro] = useState('');

  const carregar = async () => {
    const data = await getInscricoesEstaduaisByCliente(clienteId);
    setRegistros(data);
    setFiltrados(data); // inicia com todos
  };

  useEffect(() => {
    if (clienteId) carregar();
  }, [clienteId]);

  useEffect(() => {
    const termo = filtro.toLowerCase();
    const filtrados = registros.filter(r =>
      r.numero?.toLowerCase().includes(termo)
    );
    setFiltrados(filtrados);
  }, [filtro, registros]);

  const handleSalvar = async (form) => {
    if (form.id) {
      await updateInscricaoEstadual(clienteId, form.id, form);
      setMensagem('Atualizado com sucesso!');
    } else {
      await createInscricaoEstadual(clienteId, form);
      setMensagem('Salvo com sucesso!');
    }
    setOpenMsg(true);
    setFormVisivel(false);
    setItemSelecionado(null);
    carregar();
  };

  const handleExcluir = async (id) => {
    if (window.confirm('Excluir este registro?')) {
      await deleteInscricaoEstadual(clienteId, id);
      setMensagem('Excluído com sucesso!');
      setOpenMsg(true);
      carregar();
    }
  };

  return (
    <Box>
      <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 2 }}>
        <TextField
          label="Buscar por número"
          variant="outlined"
          size="small"
          value={filtro}
          onChange={(e) => setFiltro(e.target.value)}
          sx={{ mr: 2 }}
        />
        <Button variant="contained" onClick={() => { setItemSelecionado(null); setFormVisivel(true); }}>
          Nova Inscrição Estadual
        </Button>
      </Box>

      {formVisivel && (
        <InscricaoEstadualForm
          data={itemSelecionado}
          onSubmit={handleSalvar}
          onCancel={() => { setFormVisivel(false); setItemSelecionado(null); }}
        />
      )}

      <Box sx={{ height: 300 }}>
        <DataGrid
          rows={filtrados}
          columns={[
            { field: 'id', headerName: 'ID', width: 90 },
            { field: 'numero', headerName: 'Número', flex: 1 },
            {
              field: 'dataCadastro',
              headerName: 'Data de Cadastro',
              flex: 1,
              valueFormatter: (params) => params?.value?.substring(0, 10)
            },
            {
              field: 'acoes',
              headerName: 'Ações',
              width: 180,
              renderCell: (params) => (
                <>
                  <Button onClick={() => { setItemSelecionado(params.row); setFormVisivel(true); }}>Editar</Button>
                  <Button color="error" onClick={() => handleExcluir(params.row.id)}>Excluir</Button>
                </>
              )
            }
          ]}
          pageSize={5}
          rowsPerPageOptions={[5]}
          disableSelectionOnClick
          getRowId={(row) => row.id}
        />
      </Box>

      <Snackbar open={openMsg} autoHideDuration={3000} onClose={() => setOpenMsg(false)}>
        <Alert onClose={() => setOpenMsg(false)} severity="success" sx={{ width: '100%' }}>
          {mensagem}
        </Alert>
      </Snackbar>
    </Box>
  );
};

export default InscricoesEstaduais;
