import { useEffect, useState } from 'react';
import { Box, Button, Snackbar, Alert } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import CnpjForm from '../components/CnpjForm';
import {
  getCnpjByCliente,
  createOrUpdateCnpj,
  deleteCnpj
} from '../services/cnpjService';

const Cnpj = ({ clienteId }) => {
  const [cnpj, setCnpj] = useState(null);
  const [editando, setEditando] = useState(false);
  const [mensagem, setMensagem] = useState('');
  const [openMsg, setOpenMsg] = useState(false);

  const carregar = async () => {
    try {
      const data = await getCnpjByCliente(clienteId);
      setCnpj(data);
    } catch (err) {
      console.error('Erro ao carregar CNPJ:', err);
    }
  };

  useEffect(() => {
    if (clienteId) carregar();
  }, [clienteId]);

  const handleSalvar = async (form) => {
    await createOrUpdateCnpj(clienteId, form);
    setMensagem('CNPJ salvo com sucesso!');
    setOpenMsg(true);
    setEditando(false);
    carregar();
  };

  const handleExcluir = async () => {
    if (window.confirm('Deseja excluir o CNPJ?')) {
      await deleteCnpj(clienteId);
      setMensagem('CNPJ excluído com sucesso!');
      setOpenMsg(true);
      setCnpj(null);
    }
  };

  return (
    <Box>
      <Box sx={{ display: 'flex', justifyContent: 'flex-end', mb: 2 }}>
        {!cnpj && (
          <Button variant="contained" onClick={() => setEditando(true)}>Cadastrar CNPJ</Button>
        )}
      </Box>

      {editando && (
        <CnpjForm
          cnpjData={cnpj}
          onSubmit={handleSalvar}
          onCancel={() => setEditando(false)}
        />
      )}

      {!editando && cnpj && (
        <Box sx={{ height: 180, width: '100%' }}>
          <DataGrid
            rows={[{ ...cnpj, id: 1 }]}
            columns={[
              { field: 'cnpj', headerName: 'CNPJ', flex: 1 },
              {
                field: 'dataCadastro',
                headerName: 'Data de Cadastro',
                flex: 1,
                // valueFormatter: (params) => {
                //   const raw = params?.value;
                //   return typeof raw === 'string' ? raw.substring(0, 10) : '';
                // }

                // valueFormatter: (params) => {
                //   if (!params.value) return '';
                //   const data = new Date(params.value);
                //   return data.toISOString().substring(0, 10);
                // }
              },
              
              {
                field: 'acoes',
                headerName: 'Ações',
                width: 180,
                sortable: false,
                renderCell: () => (
                  <>
                    <Button size="small" onClick={() => setEditando(true)}>Editar</Button>
                    <Button size="small" color="error" onClick={handleExcluir}>Excluir</Button>
                  </>
                )
              }
            ]}
            hideFooterPagination
            disableSelectionOnClick
            autoHeight
          />
        </Box>
      )}

      <Snackbar open={openMsg} autoHideDuration={3000} onClose={() => setOpenMsg(false)}>
        <Alert onClose={() => setOpenMsg(false)} severity="success" sx={{ width: '100%' }}>
          {mensagem}
        </Alert>
      </Snackbar>
    </Box>
  );
};

export default Cnpj;
