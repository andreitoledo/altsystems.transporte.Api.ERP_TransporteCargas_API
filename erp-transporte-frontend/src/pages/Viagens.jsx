import { useEffect, useState } from 'react';
import { Button, Grid, Typography, TextField } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { getViagens, deleteViagem } from '../services/viagemService';
import DataTable from '../components/DataTable';
import { useSnackbar } from 'notistack';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import VisibilityIcon from '@mui/icons-material/Visibility';
import { IconButton, Tooltip } from '@mui/material';

const Viagens = () => {
  const [viagens, setViagens] = useState([]);
  const [busca, setBusca] = useState('');
  const { enqueueSnackbar } = useSnackbar();
  const navigate = useNavigate();

  const carregarViagens = async () => {
    const dados = await getViagens();
    setViagens(dados);
  };

  useEffect(() => {
    carregarViagens();
  }, []);

  const handleExcluir = async (id) => {
    await deleteViagem(id);
    enqueueSnackbar('Viagem excluída com sucesso!', { variant: 'success' });
    carregarViagens();
  };

  const handleVisualizar = (id) => {
    navigate(`/viagens/${id}/detalhe`);
  };

  const colunas = [
    { field: 'id', headerName: 'ID', width: 70 },
    { field: 'veiculo', headerName: 'Veículo', width: 150, valueGetter: (params) => params.row.veiculo?.modelo || '-' },
    { field: 'motorista', headerName: 'Motorista', width: 150, valueGetter: (params) => params.row.motorista?.nome || '-' },
    { field: 'dataSaida', headerName: 'Saída', width: 140 },
    { field: 'dataChegada', headerName: 'Chegada', width: 140 },
    {
      field: 'acoes',
      headerName: 'Ações',
      width: 160,
      renderCell: (params) => (
        <>
          <Tooltip title="Editar">
            <IconButton color="primary" onClick={() => navigate(`/viagens/${params.row.id}/detalhe`)}>
              <EditIcon />
            </IconButton>
          </Tooltip>
          <Tooltip title="Excluir">
            <IconButton color="error" onClick={() => handleExcluir(params.row.id)}>
              <DeleteIcon />
            </IconButton>
          </Tooltip>
          <Tooltip title="Detalhes">
            <IconButton onClick={() => handleVisualizar(params.row.id)}>
              <VisibilityIcon />
            </IconButton>
          </Tooltip>
        </>
      ),
    },
  ];

  return (
    <>
      <Typography variant="h4" gutterBottom>Viagens</Typography>
      <Grid container spacing={2} sx={{ mb: 2 }}>
        <Grid item xs={6}>
          <TextField
            label="Buscar por veículo ou motorista"
            fullWidth
            value={busca}
            onChange={(e) => setBusca(e.target.value)}
          />
        </Grid>
        <Grid item xs={6}>
          <Button variant="contained" fullWidth onClick={() => navigate('/viagens/nova')}>
            Nova Viagem
          </Button>

        </Grid>
      </Grid>

      <DataTable
        rows={viagens}
        columns={colunas}
        onEdit={(id) => navigate(`/viagens/${id}/detalhe`)}
        onDelete={handleExcluir}
      />
    </>
  );
};

export default Viagens;
