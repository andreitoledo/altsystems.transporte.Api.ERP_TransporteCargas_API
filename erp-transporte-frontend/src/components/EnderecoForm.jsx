import { useEffect, useState } from 'react';
import { Grid, TextField, Button, Box } from '@mui/material';

const EnderecoForm = ({ endereco = {}, onSubmit, onCancel }) => {
  const [form, setForm] = useState({
    logradouro: '',
    cidade: '',
    estado: ''
  });

  useEffect(() => {
    if (endereco) {
      setForm({
        logradouro: endereco.logradouro || '',
        cidade: endereco.cidade || '',
        estado: endereco.estado || ''
      });
    }
  }, [endereco]);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = () => {
    if (!form.logradouro || !form.cidade || !form.estado) {
      alert('Preencha todos os campos');
      return;
    }
    onSubmit({ ...endereco, ...form });
  };

  return (
    <Box sx={{ mb: 2 }}>
      <Grid container spacing={2}>
        <Grid item xs={12} md={4}>
          <TextField
            name="logradouro"
            label="Logradouro *"
            value={form.logradouro}
            onChange={handleChange}
            fullWidth
            variant="outlined"
          />
        </Grid>
        <Grid item xs={12} md={4}>
          <TextField
            name="cidade"
            label="Cidade *"
            value={form.cidade}
            onChange={handleChange}
            fullWidth
            variant="outlined"
          />
        </Grid>
        <Grid item xs={12} md={4}>
          <TextField
            name="estado"
            label="UF *"
            value={form.estado}
            onChange={handleChange}
            fullWidth
            variant="outlined"
          />
        </Grid>
        <Grid item xs={12} md={6}>
          <Button variant="contained" onClick={handleSubmit} fullWidth>
            Salvar
          </Button>
        </Grid>
        <Grid item xs={12} md={6}>
          {onCancel && (
            <Button onClick={onCancel} fullWidth>
              Cancelar
            </Button>
          )}
        </Grid>
      </Grid>
    </Box>
  );
};

export default EnderecoForm;
