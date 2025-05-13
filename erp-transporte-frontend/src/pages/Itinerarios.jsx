import { useEffect, useState } from 'react';
import {
  Button, Typography, Dialog, DialogTitle, DialogContent,
  DialogActions
} from '@mui/material';
import {
  getItinerariosByViagem,
  deleteItinerario,
  createItinerario,
  updateItinerario
} from '../services/itinerarioService';
import { useSnackbar } from 'notistack';
import DataTable from '../components/DataTable';
import ItinerarioForm from '../components/ItinerarioForm';

const Itinerarios = ({ viagemId }) => {
  const [itinerarios, setItinerarios] = useState([]);
  const [open, setOpen] = useState(false);
  const [formData, setFormData] = useState(null); // null = novo
  const { enqueueSnackbar } = useSnackbar();

  const carregar = async () => {
    try {
      const dados = await getItinerariosByViagem(viagemId);
      setItinerarios(dados);
    } catch (err) {
      console.error("Erro ao carregar itinerários", err);
      enqueueSnackbar('Erro ao carregar itinerários.', { variant: 'error' });
    }
  };

  useEffect(() => {
    if (viagemId) carregar();
  }, [viagemId]);

  const handleExcluir = async (id) => {
    try {
      await deleteItinerario(id);
      enqueueSnackbar('Itinerário removido!', { variant: 'success' });
      carregar();
    } catch {
      enqueueSnackbar('Erro ao remover itinerário.', { variant: 'error' });
    }
  };

  const handleSalvar = async (data) => {
    try {
      if (data.id) {
        await updateItinerario(data.id, data);
        enqueueSnackbar('Itinerário atualizado com sucesso!', { variant: 'success' });
      } else {
        await createItinerario({ ...data, viagemId: parseInt(viagemId) });
        enqueueSnackbar('Itinerário adicionado com sucesso!', { variant: 'success' });
      }

      setOpen(false);
      setFormData(null);
      carregar();
    } catch (err) {
      console.error("Erro ao salvar itinerário", err);
      enqueueSnackbar('Erro ao salvar itinerário.', { variant: 'error' });
    }
  };

  const colunas = [
    { field: 'id', headerName: 'ID' },
    { field: 'local', headerName: 'Local' },
    { field: 'horaPrevista', headerName: 'Hora Prevista' },
    {
      field: 'acoes',
      headerName: 'Ações',
      renderCell: ({ row, onDelete, onEdit }) => (
        <>
          <Button size="small" onClick={() => onEdit(row)}>Editar</Button>
          <Button size="small" color="error" onClick={() => onDelete(row.id)}>Excluir</Button>
        </>
      ),
    },
  ];

  return (
    <>
      <Typography variant="h6" gutterBottom>Itinerário da Viagem</Typography>

      <DataTable
        rows={itinerarios}
        columns={colunas}
        onDelete={handleExcluir}
        onEdit={(row) => {
          setFormData(row);
          setOpen(true);
        }}
      />

      <Button variant="contained" sx={{ mt: 2 }} onClick={() => {
        setFormData(null);
        setOpen(true);
      }}>
        Adicionar Itinerário
      </Button>

      <Dialog open={open} onClose={() => setOpen(false)} maxWidth="sm" fullWidth>
        <DialogTitle>{formData?.id ? 'Editar' : 'Novo'} Itinerário</DialogTitle>
        <DialogContent>
          <ItinerarioForm
            itinerarioData={formData}
            onSubmit={handleSalvar}
            onCancel={() => setOpen(false)}
          />
        </DialogContent>
        <DialogActions />
      </Dialog>
    </>
  );
};

export default Itinerarios;
