import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Tab, Tabs, Box } from '@mui/material';
import ViagemForm from '../components/ViagemForm';
import Itinerarios from '../pages/Itinerarios';
import { getViagemById } from '../services/viagemService';

const ViagemDetalhe = () => {
  const { id } = useParams();
  const [tab, setTab] = useState(0);
  const [viagem, setViagem] = useState(null);

  useEffect(() => {
    if (id === 'nova') {
      setViagem({}); // seta vazio para renderizar o form
      return;
    }
  
    const fetchData = async () => {
      try {
        const v = await getViagemById(id);
        setViagem(v);
      } catch (error) {
        console.error('Erro ao buscar viagem:', error);
      }
    };
    fetchData();
  }, [id]);

  // Impede o erro de aba inválida
  if (!viagem) return <p>Carregando...</p>;

  return (
    <Box>
      <Tabs value={tab} onChange={(e, newTab) => setTab(newTab)} sx={{ mb: 2 }}>
        <Tab label="Viagem" />
        <Tab label="Itinerário" />
      </Tabs>

      {tab === 0 && <ViagemForm viagemData={viagem} />}
      {tab === 1 && <Itinerarios viagemId={id} />}
    </Box>
  );
};


export default ViagemDetalhe;
