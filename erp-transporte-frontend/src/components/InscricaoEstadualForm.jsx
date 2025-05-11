import { Grid, TextField, Button, Box } from '@mui/material';
import { useEffect, useState } from 'react';

const InscricaoEstadualForm = ({ data = {}, onSubmit, onCancel }) => {
  const [form, setForm] = useState({
    numero: '',
    dataCadastro: ''
  });

  useEffect(() => {
    if (data) {
      setForm({
        numero: data.numero || '',
        dataCadastro: data.dataCadastro?.substring(0, 10) || ''
      });
    }
  }, [data]);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = () => {
    if (!form.numero || !form.dataCadastro) {
      alert('Preencha todos os campos');
      return;
    }
    onSubmit({ ...data, ...form });
  };

  return (
    <Box sx={{ mb: 2 }}>
      <Grid container spacing={2}>
        <Grid item xs={6}>
          <TextField name="numero" label="Número IE *" value={form.numero} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={6}>
          <TextField
            name="dataCadastro"
            label="Data de Cadastro *"
            type="date"
            value={form.dataCadastro}
            onChange={handleChange}
            fullWidth
            InputLabelProps={{ shrink: true }}
          />
        </Grid>
        <Grid item xs={6}>
          <Button variant="contained" onClick={handleSubmit} fullWidth>Salvar</Button>
        </Grid>
        <Grid item xs={6}>
          {onCancel && <Button onClick={onCancel} fullWidth>Cancelar</Button>}
        </Grid>
      </Grid>
    </Box>
  );
};

export default InscricaoEstadualForm;
