import { Box, Button, Grid, TextField } from '@mui/material';
import { useState } from 'react';

const ClienteForm = ({ onSubmit, initialData = {} }) => {
  const [form, setForm] = useState({
    nome: initialData.nome || '',
    email: initialData.email || '',
    telefone: initialData.telefone || ''
  });

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(form);
  };

  return (
    <Box component="form" onSubmit={handleSubmit} sx={{ mt: 2 }}>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={4}>
          <TextField label="Nome" fullWidth name="nome" value={form.nome} onChange={handleChange} required />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField label="E-mail" fullWidth name="email" value={form.email} onChange={handleChange} required />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField label="Telefone" fullWidth name="telefone" value={form.telefone} onChange={handleChange} />
        </Grid>
        <Grid item xs={12}>
          <Button type="submit" variant="contained">Salvar</Button>
        </Grid>
      </Grid>
    </Box>
  );
};

export default ClienteForm;