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
      setDadosGerais(Array.isArray(data) ? data : [data]);
    } catch (err) {
      console.error('Erro ao carregar dados gerais:', err);
    }
    setLoading(false);
  };

  useEffect(() => {
    if (clienteId) carregarDados();
  }, [clienteId]);

  const handleSalvar = async (dados) => {
    const payload = { ...dados };
    if (!payload.id || payload.id === 0) {
      delete payload.id;
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
            setItemSelecionado(null);
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

      <Box sx={{ height: 400, width: '100%' }}>
        {!loading && (
          <DataGrid
            rows={dadosGerais}
            columns={[
              { field: 'id', headerName: 'ID', width: 90 },
              { field: 'ramoAtividade', headerName: 'Ramo de Atividade', flex: 1 },
              { field: 'tipoCadastro', headerName: 'Tipo de Cadastro', flex: 1 },
              { field: 'statusCadastro', headerName: 'Ativo?', width: 100, 
                valueFormatter: (params) => params.value ? 'Sim' : 'Não'
              },
              {
                field: 'dataCadastro',
                headerName: 'Data de Cadastro',
                width: 160,
                valueFormatter: (params) => params.value?.substring(0, 10)
              },
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
