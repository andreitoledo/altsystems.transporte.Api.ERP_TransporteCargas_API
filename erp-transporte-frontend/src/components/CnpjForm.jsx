import { useEffect, useState } from 'react';
import { Grid, TextField, Button, Box } from '@mui/material';
import InputMask from 'react-input-mask';

const CnpjForm = ({ cnpjData = {}, onSubmit, onCancel }) => {
  const [form, setForm] = useState({
    cnpj: '',
    dataCadastro: ''
  });

  useEffect(() => {
    if (cnpjData) {
      setForm({
        id: cnpjData.id || 0,
        cnpj: cnpjData.cnpj ?? '', // <- ESSENCIAL para preencher o campo!
        dataCadastro: cnpjData.dataCadastro?.substring(0, 10) || ''
      });
    } else {
      setForm({
        id: 0,
        cnpj: '',
        dataCadastro: ''
      });
    }
  }, [cnpjData]);


  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  // Função para lidar com o envio do formulário
  // Aqui você pode adicionar a lógica para enviar os dados do formulário
  const handleSubmit = () => {
    if (!form.cnpj || !form.dataCadastro) {
      alert('Preencha todos os campos');
      return;
    }

    // Remover pontos, barra e hífen
    const cnpjLimpo = form.cnpj.replace(/[^\d]/g, '');

    onSubmit({ ...form, cnpj: cnpjLimpo });
  };


  return (
    <Box sx={{ mb: 2 }}>
      <Grid container spacing={2}>
        <Grid xs={12} md={6}>
          <TextField label="CNPJ" name="cnpj" value={form.cnpj} onChange={handleChange} fullWidth />
        </Grid>

        {/* <Grid item xs={12} md={6}>
          <InputMask
            mask="99.999.999/9999-99"
            value={form.cnpj}
            onChange={handleChange}
          >
            {() => (
              <TextField
                label="CNPJ"
                name="cnpj"
                fullWidth
              />
            )}
          </InputMask>
        </Grid> */}

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
