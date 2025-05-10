import { useEffect, useState } from 'react';
import { Box, TextField, Button } from '@mui/material';

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
    <Box sx={{ display: 'flex', gap: 2, mb: 2 }}>
      <TextField name="logradouro" label="Logradouro *" value={form.logradouro} onChange={handleChange} fullWidth />
      <TextField name="cidade" label="Cidade *" value={form.cidade} onChange={handleChange} fullWidth />
      <TextField name="estado" label="UF *" value={form.estado} onChange={handleChange} fullWidth />
      <Button variant="contained" onClick={handleSubmit}>Salvar</Button>
      {onCancel && <Button onClick={onCancel}>Cancelar</Button>}
    </Box>
  );
};

export default EnderecoForm;