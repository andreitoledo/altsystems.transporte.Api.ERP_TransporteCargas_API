import { useEffect, useState } from 'react';
import { Grid, TextField, Button, Box, FormControlLabel, Checkbox } from '@mui/material';

const DadosGeraisForm = ({ dados = {}, onSubmit, onCancel }) => {
  const [form, setForm] = useState({
    ramoAtividade: '',
    observacoes: '',
    tipoCadastro: '',
    statusCadastro: true,
    dataCadastro: ''
  });

  useEffect(() => {
    if (dados) {
      setForm({
        ramoAtividade: dados.ramoAtividade || '',
        observacoes: dados.observacoes || '',
        tipoCadastro: dados.tipoCadastro || '',
        statusCadastro: dados.statusCadastro ?? true,
        dataCadastro: dados.dataCadastro ? dados.dataCadastro.substring(0, 10) : ''
      });
    }
  }, [dados]);

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setForm({ ...form, [name]: type === 'checkbox' ? checked : value });
  };

  const handleSubmit = () => {
    const { dataCadastro } = form;
    if (!dataCadastro) {
      alert('Preencha todos os campos obrigatórios.');
      return;
    }
    onSubmit({ ...dados, ...form });
  };

  return (
    <Box sx={{ mb: 2 }}>
      <Grid container spacing={2}>
        <Grid item xs={12} md={6}>
          <TextField
            name="ramoAtividade"
            label="Ramo de Atividade"
            value={form.ramoAtividade}
            onChange={handleChange}
            fullWidth
          />
        </Grid>
        <Grid item xs={12} md={6}>
          <TextField
            name="tipoCadastro"
            label="Tipo de Cadastro"
            value={form.tipoCadastro}
            onChange={handleChange}
            fullWidth
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            name="observacoes"
            label="Observações"
            value={form.observacoes}
            onChange={handleChange}
            fullWidth
            multiline
            rows={3}
          />
        </Grid>
        <Grid item xs={12} md={6}>
          <FormControlLabel
            control={
              <Checkbox
                name="statusCadastro"
                checked={form.statusCadastro}
                onChange={handleChange}
              />
            }
            label="Cadastro Ativo"
          />
        </Grid>
        <Grid item xs={12} md={6}>
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

export default DadosGeraisForm;
