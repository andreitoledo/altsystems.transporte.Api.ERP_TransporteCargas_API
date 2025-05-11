import { useEffect, useState } from 'react';
import { Grid, TextField, Button, Box } from '@mui/material';

const DadosGeraisForm = ({ dados = {}, onSubmit, onCancel }) => {
  const [form, setForm] = useState({
    //cnpj: '',
    //inscricaoEstadual: '',
    dataCadastro: ''
  });

  useEffect(() => {
    if (dados) {
      setForm({
        //cnpj: dados.cnpj || '',
        //inscricaoEstadual: dados.inscricaoEstadual || '',
        dataCadastro: dados.dataCadastro ? dados.dataCadastro.substring(0, 10) : ''
      });
    }
  }, [dados]);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = () => {
    const { dataCadastro } = form;
    if ( !dataCadastro) {
      alert('Preencha todos os campos obrigatórios.');
      return;
    }

    onSubmit({ ...dados, ...form });
  };

  return (
    <Box sx={{ mb: 2 }}>
      <Grid container spacing={2}>
        {/* <Grid item xs={12} md={4}>
          <TextField
            name="cnpj"
            label="CNPJ *"
            value={form.cnpj}
            onChange={handleChange}
            fullWidth
          />
        </Grid> */}
        {/* <Grid item xs={12} md={4}>
          <TextField
            name="inscricaoEstadual"
            label="Inscrição Estadual *"
            value={form.inscricaoEstadual}
            onChange={handleChange}
            fullWidth
          />
        </Grid> */}
        <Grid item xs={12} md={4}>
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
