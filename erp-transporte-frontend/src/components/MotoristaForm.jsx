import { useEffect, useState } from 'react';
import { Grid, TextField, Button, Box } from '@mui/material';

const MotoristaForm = ({ motoristaData = {}, onSubmit, onCancel }) => {
  const [form, setForm] = useState({
    nome: '',
    cpf: '',
    cnh: '',
    categoriaCnh: '',
    validadeCnh: '',
    telefone: '',
    categoria: '',
    dataAdmissao: '',
    ativo: true
  });

  useEffect(() => { 
    if (motoristaData) {
      setForm({
        nome: motoristaData.nome || '',
        cpf: motoristaData.cpf || '',
        cnh: motoristaData.cnh || '',
        categoria: motoristaData.categoria || '',
        telefone: motoristaData.telefone || '',
        validadeCnh: motoristaData.validadeCnh
          ? motoristaData.validadeCnh.substring(0, 10)
          : '',
        dataAdmissao: motoristaData.dataAdmissao?.substring(0, 10) || '',
        ativo: motoristaData.ativo ?? true,
        id: motoristaData.id || 0
      });
    }
  }, [motoristaData]);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = () => {
    onSubmit({ ...form });
  };

  return (
    <Box sx={{ mb: 2 }}>
      <Grid container spacing={2}>
        <Grid item xs={12} md={6}>
          <TextField name="nome" label="Nome" value={form.nome} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={12} md={3}>
          <TextField name="cpf" label="CPF" value={form.cpf} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={12} md={3}>
          <TextField name="telefone" label="Telefone" value={form.telefone} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={12} md={3}>
          <TextField name="cnh" label="CNH" value={form.cnh} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={12} md={3}>
          <TextField name="categoria" label="Categoria" value={form.categoria} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={12} md={3}>
          <TextField name="validadeCnh" label="Validade CNH" type="date" value={form.validadeCnh} onChange={handleChange} fullWidth InputLabelProps={{ shrink: true }} />
        </Grid>
        <Grid item xs={12} md={3}>
          <TextField name="dataAdmissao" label="Data de Admissão" type="date" value={form.dataAdmissao} onChange={handleChange} fullWidth InputLabelProps={{ shrink: true }} />
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

export default MotoristaForm;
