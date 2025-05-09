
import { useEffect, useState } from 'react';
import { Box, TextField, Button } from '@mui/material';

const ClienteForm = ({ cliente = {}, onSubmit, onCancel }) => {
  const [form, setForm] = useState({
    nome: '',
    email: '',
    telefone: ''
  });

  useEffect(() => {
    if (cliente) {
      setForm({
        nome: cliente.nome || '',
        email: cliente.email || '',
        telefone: cliente.telefone || ''
      });
    }
  }, [cliente]);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = () => {
    if (!form.nome || !form.email || !form.telefone) {
      alert('Preencha todos os campos');
      return;
    }
    onSubmit({ ...cliente, ...form });
  };

  return (
    <Box sx={{ display: 'flex', gap: 2, mb: 2 }}>
      <TextField
        name="nome"
        label="Nome *"
        value={form.nome}
        onChange={handleChange}
        fullWidth
      />
      <TextField
        name="email"
        label="E-mail *"
        value={form.email}
        onChange={handleChange}
        fullWidth
      />
      <TextField
        name="telefone"
        label="Telefone *"
        value={form.telefone}
        onChange={handleChange}
        fullWidth
      />
      <Button variant="contained" onClick={handleSubmit}>Salvar</Button>
      {onCancel && <Button onClick={onCancel}>Cancelar</Button>}
    </Box>
  );
};

export default ClienteForm;
