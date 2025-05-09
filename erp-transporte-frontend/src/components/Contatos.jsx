import { useEffect, useState } from 'react';
import { DataGrid } from '@mui/x-data-grid';
import { Box, CircularProgress } from '@mui/material';
import { getContatosByCliente } from '../services/contatoService';

const Contatos = ({ clienteId }) => {
  const [contatos, setContatos] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getContatosByCliente(clienteId)
      .then(setContatos)
      .catch(err => console.error('Erro ao buscar contatos:', err))
      .finally(() => setLoading(false));
  }, [clienteId]);

  const columns = [
    { field: 'nome', headerName: 'Nome', width: 200 },
    { field: 'email', headerName: 'E-mail', width: 200 },
    { field: 'telefone', headerName: 'Telefone', width: 150 }
  ];

  return (
    <Box sx={{ height: 300 }}>
      {loading ? <CircularProgress /> : (
        <DataGrid rows={contatos} columns={columns} pageSize={5} />
      )}
    </Box>
  );
};

export default Contatos;
