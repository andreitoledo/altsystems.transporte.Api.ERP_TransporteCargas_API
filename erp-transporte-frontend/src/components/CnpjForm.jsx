import { useEffect, useState } from 'react';
import { Grid, TextField, Button, Box } from '@mui/material';

const CnpjForm = ({ cnpjData = {}, onSubmit, onCancel }) => {
  const [form, setForm] = useState({
    cnpj: '',
    dataCadastro: ''
  });

  useEffect(() => {
    if (cnpjData) {
      setForm({
        cnpj: cnpjData.cnpj || '',
        dataCadastro: cnpjData.dataCadastro?.substring(0, 10) || ''
      });
    }
  }, [cnpjData]);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = () => {
    if (!form.cnpj || !form.dataCadastro) {
      alert('Preencha todos os campos');
      return;
    }
    onSubmit(form);
  };

  return (
    <Box sx={{ mb: 2 }}>
      <Grid container spacing={2}>
        <Grid xs={12} md={6}>
          <TextField label="CNPJ" name="cnpj" value={form.cnpj} onChange={handleChange} fullWidth />
        </Grid>
        <Grid xs={12} md={6}>
          <TextField
            label="Data de Cadastro"
            name="dataCadastro"
            type="date"
            value={form.dataCadastro}
            onChange={handleChange}
            fullWidth
            InputLabelProps={{ shrink: true }}
          />
        </Grid>
        <Grid xs={6}>
          <Button variant="contained" onClick={handleSubmit} fullWidth>Salvar</Button>
        </Grid>
        <Grid xs={6}>
          {onCancel && <Button onClick={onCancel} fullWidth>Cancelar</Button>}
        </Grid>
      </Grid>
    </Box>
  );
};

export default CnpjForm;
