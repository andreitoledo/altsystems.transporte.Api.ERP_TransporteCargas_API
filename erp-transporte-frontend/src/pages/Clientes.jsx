import { useEffect, useState } from 'react';
import { Box, Button, TextField, Typography } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import ClienteForm from '../components/ClienteForm';
import { getClientes, createCliente } from '../services/clienteService';

const Clientes = () => {
  const [clientes, setClientes] = useState([]);
  const [filtro, setFiltro] = useState('');
  const [openForm, setOpenForm] = useState(false);

  const carregarClientes = async () => {
    const data = await getClientes();
    setClientes(data);
  };

  useEffect(() => {
    carregarClientes();
  }, []);

  const handleSalvar = async (cliente) => {
    await createCliente(cliente);
    setOpenForm(false);
    carregarClientes();
  };

  const clientesFiltrados = clientes.filter(c =>
    c.nome.toLowerCase().includes(filtro.toLowerCase())
  );

  return (
    <Box>
      <Typography variant="h4" sx={{ mb: 2 }}>Cadastro de Clientes</Typography>
      <Box sx={{ display: 'flex', gap: 2, mb: 2 }}>
        <TextField label="Filtrar por nome" value={filtro} onChange={(e) => setFiltro(e.target.value)} />
        <Button variant="contained" onClick={() => setOpenForm(true)}>Novo Cliente</Button>
      </Box>

      {openForm && <ClienteForm onSubmit={handleSalvar} />}

      <Box sx={{ height: 400 }}>
        <DataGrid
          rows={clientesFiltrados}
          columns={[
            { field: 'id', headerName: 'ID', width: 90 },
            { field: 'nome', headerName: 'Nome', flex: 1 },
            { field: 'email', headerName: 'Email', flex: 1 },
            { field: 'telefone', headerName: 'Telefone', width: 150 }
          ]}
          pageSize={5}
          rowsPerPageOptions={[5, 10, 20]}
        />
      </Box>
    </Box>
  );
};

export default Clientes;