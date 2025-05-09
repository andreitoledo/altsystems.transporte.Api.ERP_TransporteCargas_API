import { useEffect, useState } from 'react';
import { DataGrid } from '@mui/x-data-grid';
import { Box, CircularProgress } from '@mui/material';
import { getEnderecosByCliente } from '../services/enderecoService';

const Enderecos = ({ clienteId }) => {
  const [enderecos, setEnderecos] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getEnderecosByCliente(clienteId)
      .then(setEnderecos)
      .catch(err => console.error('Erro ao buscar endereços:', err))
      .finally(() => setLoading(false));
  }, [clienteId]);

  const columns = [
    { field: 'logradouro', headerName: 'Logradouro', width: 200 },
    { field: 'cidade', headerName: 'Cidade', width: 150 },
    { field: 'estado', headerName: 'UF', width: 80 }
  ];

  return (
    <Box sx={{ height: 300 }}>
      {loading ? <CircularProgress /> : (
        <DataGrid rows={enderecos} columns={columns} pageSize={5} />
      )}
    </Box>
  );
};

export default Enderecos;
