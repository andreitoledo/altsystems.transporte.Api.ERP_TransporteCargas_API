import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getClienteById } from '../services/clienteService';
import { Box, CircularProgress, Tabs, Tab, Typography } from '@mui/material';
import DadosGerais from '../pages/DadosGerais';
import Enderecos from '../pages/Enderecos';
import Contatos from '../pages/Contatos';
import Cnpj from '../pages/Cnpj';
import InscricaoEstadual from '../pages/InscricoesEstaduais';

const ClienteDetalhes = () => {
  const { id } = useParams();
  const [cliente, setCliente] = useState(null);
  const [loading, setLoading] = useState(true);
  const [tab, setTab] = useState(0);

  useEffect(() => {
    getClienteById(id)
      .then(setCliente)
      .catch(err => console.error('Erro ao buscar cliente', err))
      .finally(() => setLoading(false));
  }, [id]);

  const handleChange = (_, newValue) => setTab(newValue);

  if (loading) return <CircularProgress />;
  if (!cliente) return <Typography color="error">Cliente não encontrado.</Typography>;

  return (
    <Box sx={{ width: '100%' }}>
      <Typography variant="h5" sx={{ mb: 2 }}>
        Cliente #{id} – {cliente.nome}
      </Typography>

      <Tabs value={tab} onChange={handleChange}>
        <Tab label="Dados Gerais" />
        <Tab label="Endereços" />
        <Tab label="Contatos" />
        <Tab label="Cnpj" />
        <Tab label="IEstadual" />
      </Tabs>

      <Box sx={{ p: 2 }}>
      {tab === 0 && <DadosGerais clienteId={id} cliente={cliente} />}
        {tab === 1 && <Enderecos clienteId={id} />}
        {tab === 2 && <Contatos clienteId={id} />}
        {tab === 3 && <Cnpj clienteId={id} />}
        {tab === 4 && <InscricaoEstadual clienteId={id} />}
      </Box>
    </Box>
  );
};

export default ClienteDetalhes;
