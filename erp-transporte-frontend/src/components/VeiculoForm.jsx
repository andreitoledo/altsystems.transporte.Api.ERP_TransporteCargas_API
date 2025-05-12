import { useState, useEffect } from 'react';
import {
  Grid, TextField, Button, Box
} from '@mui/material';

const VeiculoForm = ({ dados = {}, onSubmit, onCancel }) => {
  const [form, setForm] = useState({
    placa: '',
    renavam: '',
    chassi: '',
    marca: '',
    modelo: '',
    tipo: '',
    capacidade: '',
    ano: '',
    anoFabricacao: '',
    anoModelo: '',
    dataCadastro: ''
  });

  useEffect(() => {
    if (dados) {
      setForm({
        ...dados,
        dataCadastro: dados.dataCadastro?.substring(0, 10) || ''
      });
    }
  }, [dados]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = () => {
    onSubmit({ ...form });
  };

  return (
    <Box sx={{ mb: 2 }}>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={4}>
          <TextField label="Placa" name="placa" value={form.placa} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField label="Renavam" name="renavam" value={form.renavam} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField label="Chassi" name="chassi" value={form.chassi} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField label="Modelo" name="modelo" value={form.modelo} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField label="Marca" name="marca" value={form.marca} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField label="Tipo" name="tipo" value={form.tipo} onChange={handleChange} fullWidth />
        </Grid>
        <Grid item xs={6} sm={3}>
          <TextField label="Capacidade" name="capacidade" value={form.capacidade} onChange={handleChange} type="number" fullWidth />
        </Grid>
        <Grid item xs={6} sm={3}>
          <TextField label="Ano" name="ano" value={form.ano} onChange={handleChange} type="number" fullWidth />
        </Grid>
        <Grid item xs={6} sm={3}>
          <TextField label="Ano Fab." name="anoFabricacao" value={form.anoFabricacao} onChange={handleChange} type="number" fullWidth />
        </Grid>
        <Grid item xs={6} sm={3}>
          <TextField label="Ano Mod." name="anoModelo" value={form.anoModelo} onChange={handleChange} type="number" fullWidth />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField
            label="Data Cadastro"
            name="dataCadastro"
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
          <Button variant="text" onClick={onCancel} fullWidth>Cancelar</Button>
        </Grid>
      </Grid>
    </Box>
  );
};

export default VeiculoForm;
