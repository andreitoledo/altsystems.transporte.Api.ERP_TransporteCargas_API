import { useEffect, useState } from 'react';
import {
  Box, Button, Snackbar, Alert, TextField, InputAdornment, IconButton
} from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import SearchIcon from '@mui/icons-material/Search';
import VeiculoForm from '../components/VeiculoForm';
import {
  getVeiculos,
  createVeiculo,
  updateVeiculo,
  deleteVeiculo
} from '../services/veiculoService';

const Veiculos = () => {
  const [veiculos, setVeiculos] = useState([]);
  const [filtro, setFiltro] = useState('');
  const [editando, setEditando] = useState(false);
  const [selecionado, setSelecionado] = useState(null);
  const [mensagem, setMensagem] = useState('');
  const [openMsg, setOpenMsg] = useState(false);

  const carregar = async () => {
    const data = await getVeiculos();
    setVeiculos(data);
  };

  useEffect(() => {
    carregar();
  }, []);

  const handleSalvar = async (dados) => {
    if (dados.id && dados.id > 0) {
      await updateVeiculo(dados.id, dados);
      setMensagem('Veículo atualizado com sucesso!');
    } else {
      await createVeiculo(dados);
      setMensagem('Veículo criado com sucesso!');
    }
    setOpenMsg(true);
    setEditando(false);
    setSelecionado(null);
    carregar();
  };

  const handleEditar = (row) => {
    setSelecionado(row);
    setEditando(true);
  };

  const handleExcluir = async (id) => {
    if (window.confirm('Confirma a exclusão?')) {
      await deleteVeiculo(id);
      setMensagem('Veículo excluído com sucesso!');
      setOpenMsg(true);
      carregar();
    }
  };

  const dadosFiltrados = veiculos.filter(v =>
    v.placa.toLowerCase().includes(filtro.toLowerCase())
  );

  return (
    <Box>
      <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 2 }}>
        <TextField
          label="Pesquisar por placa"
          variant="outlined"
          size="small"
          value={filtro}
          onChange={(e) => setFiltro(e.target.value)}
          InputProps={{
            endAdornment: (
              <InputAdornment position="end">
                <IconButton>
                  <SearchIcon />
                </IconButton>
              </InputAdornment>
            )
          }}
        />
        <Button
          variant="contained"
          onClick={() => {
            setSelecionado(null);
            setEditando(true);
          }}
        >
          Novo Veículo
        </Button>
      </Box>

      {editando && (
        <VeiculoForm
          dados={selecionado}
          onSubmit={handleSalvar}
          onCancel={() => {
            setEditando(false);
            setSelecionado(null);
          }}
        />
      )}

      <Box sx={{ height: 400, width: '100%' }}>
        <DataGrid
          rows={dadosFiltrados}
          columns={[
            { field: 'placa', headerName: 'Placa', flex: 1 },
            { field: 'marca', headerName: 'Marca', flex: 1 },
            { field: 'modelo', headerName: 'Modelo', flex: 1 },
            { field: 'tipo', headerName: 'Tipo', flex: 1 },
            {
              field: 'acoes',
              headerName: 'Ações',
              width: 180,
              sortable: false,
              renderCell: (params) => (
                <>
                  <Button size="small" onClick={() => handleEditar(params.row)}>Editar</Button>
                  <Button size="small" color="error" onClick={() => handleExcluir(params.row.id)}>Excluir</Button>
                </>
              )
            }
          ]}
          getRowId={(row) => row.id}
          pageSize={5}
          rowsPerPageOptions={[5, 10]}
          disableSelectionOnClick
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

export default Veiculos;
