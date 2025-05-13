import { useState, useEffect } from 'react';
import { Grid, TextField, Button } from '@mui/material';
import { updateViagem, createViagem } from '../services/viagemService';
import { useSnackbar } from 'notistack';

const ViagemForm = ({ viagemData = {}, onSubmitSuccess }) => {
  const [form, setForm] = useState({
    veiculoId: '',
    motoristaId: '',
    dataSaida: '',
    dataChegada: '',   
  });
  const { enqueueSnackbar } = useSnackbar();

  useEffect(() => {
    if (viagemData) {
      setForm({
        ...form,
        ...viagemData,
        dataSaida: viagemData.dataSaida?.substring(0, 10) || '',
        dataChegada: viagemData.dataChegada?.substring(0, 10) || '',
      });
    }
  }, [viagemData]);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async () => {
    if (form.id) await updateViagem(form.id, form);
    else await createViagem(form);

    enqueueSnackbar('Viagem salva com sucesso!', { variant: 'success' });
    if (onSubmitSuccess) onSubmitSuccess();
  };

  return (
    <Grid container spacing={2} sx={{ mt: 2 }}>
      <Grid item xs={6}>
        <TextField name="veiculoId" label="Veículo ID" fullWidth value={form.veiculoId} onChange={handleChange} />
      </Grid>
      <Grid item xs={6}>
        <TextField name="motoristaId" label="Motorista ID" fullWidth value={form.motoristaId} onChange={handleChange} />
      </Grid>
      <Grid item xs={6}>
        <TextField type="date" name="dataSaida" label="Data de Saída" fullWidth value={form.dataSaida} onChange={handleChange} InputLabelProps={{ shrink: true }} />
      </Grid>
      <Grid item xs={6}>
        <TextField type="date" name="dataChegada" label="Data de Chegada" fullWidth value={form.dataChegada} onChange={handleChange} InputLabelProps={{ shrink: true }} />
      </Grid>      
      <Grid item xs={12}>
        <Button variant="contained" fullWidth onClick={handleSubmit}>Salvar</Button>
      </Grid>
    </Grid>
  );
};

export default ViagemForm;
