import { useEffect, useState } from 'react';
import {
  Box, Button, Snackbar, Alert, TextField, Typography
} from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import MotoristaForm from '../components/MotoristaForm';
import {
  getMotoristas, createMotorista, updateMotorista, deleteMotorista
} from '../services/motoristaService';

const Motoristas = () => {
  const [motoristas, setMotoristas] = useState([]);
  const [editando, setEditando] = useState(false);
  const [motoristaSelecionado, setMotoristaSelecionado] = useState(null);
  const [mensagem, setMensagem] = useState('');
  const [busca, setBusca] = useState('');
  const [openMsg, setOpenMsg] = useState(false);

  const carregarMotoristas = async () => {
    const data = await getMotoristas();
    setMotoristas(data);
  };

  useEffect(() => {
    carregarMotoristas();
  }, []);

  const handleSalvar = async (form) => {
    if (form.id && form.id !== 0) {
      await updateMotorista(form.id, form);
      setMensagem('Motorista atualizado com sucesso!');
    } else {
      await createMotorista(form);
      setMensagem('Motorista cadastrado com sucesso!');
    }
    setOpenMsg(true);
    setEditando(false);
    setMotoristaSelecionado(null);
    carregarMotoristas();
  };

  const handleEditar = (dados) => {
    setMotoristaSelecionado(dados);
    setEditando(true);
  };

  const handleExcluir = async (id) => {
    if (window.confirm('Deseja excluir este motorista?')) {
      await deleteMotorista(id);
      setMensagem('Motorista excluído com sucesso!');
      setOpenMsg(true);
      carregarMotoristas();
    }
  };

  const resultadosFiltrados = motoristas.filter(m =>
    m.nome.toLowerCase().includes(busca.toLowerCase()) ||
    m.cpf.toLowerCase().includes(busca.toLowerCase())
  );

  return (
    <Box>
      <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 2 }}>
        <TextField
          label="Buscar por nome ou CPF"
          value={busca}
          onChange={(e) => setBusca(e.target.value)}
          variant="outlined"
        />
        <Button variant="contained" onClick={() => { setMotoristaSelecionado(null); setEditando(true); }}>
          Novo Motorista
        </Button>
      </Box>

      {editando && (
        <MotoristaForm
          motoristaData={motoristaSelecionado}
          onSubmit={handleSalvar}
          onCancel={() => { setEditando(false); setMotoristaSelecionado(null); }}
        />
      )}

      <Box sx={{ height: 400 }}>
        <DataGrid
          rows={resultadosFiltrados}
          columns={[
            { field: 'nome', headerName: 'Nome', flex: 1 },
            { field: 'cpf', headerName: 'CPF', width: 150 },
            { field: 'telefone', headerName: 'Telefone', width: 140 },
            { field: 'categoria', headerName: 'Cat. CNH', width: 100 },
            {
              field: 'acoes',
              headerName: 'Ações',
              width: 160,
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
          rowsPerPageOptions={[5]}
          getRowId={(row) => row.id}
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

export default Motoristas;
