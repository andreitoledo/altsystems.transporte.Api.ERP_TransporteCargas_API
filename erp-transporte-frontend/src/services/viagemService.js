import api from './api';

export const getViagens = async () => {
  const response = await api.get('/Viagem');
  console.log('Viagens da API:', response.data);
  return response.data;
};

export const getViagemById = async (id) => {
  try {
    const response = await api.get(`/Viagem/${id}`);
    return response.data;
  } catch (error) {
    console.error('Erro ao buscar viagem:', error);
    throw error;
  }
};


export const createViagem = async (viagem) => {
  await api.post('/Viagem', viagem);
};

export const updateViagem = async (id, viagem) => {
  await api.put(`/Viagem/${id}`, viagem);
};

export const deleteViagem = async (id) => {
  await api.delete(`/Viagem/${id}`);
};
