import { useEffect, useState } from 'react';
import { Box, Button, Snackbar, Alert } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import DadosGeraisForm from '../components/DadosGeraisForm';
import {
  getDadosGeraisByCliente,
  createDadosGerais,
  updateDadosGerais,
  deleteDadosGerais
} from '../services/dadosGeraisService';

const DadosGerais = ({ clienteId }) => {
  const [dadosGerais, setDadosGerais] = useState([]);
  const [loading, setLoading] = useState(true);
  const [formVisivel, setFormVisivel] = useState(false);
  const [itemSelecionado, setItemSelecionado] = useState(null);
  const [mensagem, setMensagem] = useState('');
  const [openMsg, setOpenMsg] = useState(false);

  const carregarDados = async () => {
    try {
      const data = await getDadosGeraisByCliente(clienteId);
      console.log('Resposta da API:', data);
      setDadosGerais(Array.isArray(data) ? data : [data]);
    } catch (err) {
      console.error('Erro ao carregar dados gerais:', err);
    }
    setLoading(false);
  };

  useEffect(() => {
    if (clienteId) {
      console.log('Cliente ID:', clienteId);
      carregarDados();
    }
  }, [clienteId]);

  const handleSalvar = async (dados) => {
    const payload = { ...dados };
    if (!payload.id || payload.id === 0) {
      delete payload.id; // força criação
      await createDadosGerais(clienteId, payload);
      setMensagem('Registro criado com sucesso!');
    } else {
      await updateDadosGerais(clienteId, payload.id, payload);
      setMensagem('Registro atualizado com sucesso!');
    }
    setOpenMsg(true);
    setFormVisivel(false);
    setItemSelecionado(null);
    carregarDados();
  };

  const handleEditar = (dados) => {
    setItemSelecionado(dados);
    setFormVisivel(true);
  };

  const handleExcluir = async (id) => {
    if (window.confirm('Deseja realmente excluir?')) {
      await deleteDadosGerais(clienteId, id);
      setMensagem('Registro excluído com sucesso!');
      setOpenMsg(true);
      carregarDados();
    }
  };

  return (
    <Box>
      <Box sx={{ display: 'flex', justifyContent: 'flex-end', mb: 2 }}>
        <Button
          variant="contained"
          onClick={() => {
            setItemSelecionado(null); // limpa antes de abrir o form
            setFormVisivel(true);
          }}
        >
          Novo
        </Button>
      </Box>

      {formVisivel && (
        <DadosGeraisForm
          dados={itemSelecionado}
          onSubmit={handleSalvar}
          onCancel={() => {
            setFormVisivel(false);
            setItemSelecionado(null);
          }}
        />
      )}

      <Box sx={{ height: 300, width: '100%' }}>
        {!loading && (
          <DataGrid
            rows={dadosGerais}
            columns={[
              { field: 'id', headerName: 'ID', width: 90 },
              //{ field: 'cnpj', headerName: 'CNPJ', flex: 1 },
              //{ field: 'inscricaoEstadual', headerName: 'Inscrição Estadual', flex: 1 },
              { field: 'dataCadastro', headerName: 'Data de Cadastro', width: 160 },
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
            rowsPerPageOptions={[5, 10]}
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

export default DadosGerais;
