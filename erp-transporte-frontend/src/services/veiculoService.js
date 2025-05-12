import api from './api';

export const getVeiculos = async () => {
  const response = await api.get('/Veiculo');
  return response.data;
};

export const createVeiculo = async (veiculo) => {
  const response = await api.post('/Veiculo', veiculo);
  return response.data;
};

export const updateVeiculo = async (id, veiculo) => {
  const response = await api.put(`/Veiculo/${id}`, veiculo);
  return response.data;
};

export const deleteVeiculo = async (id) => {
  await api.delete(`/Veiculo/${id}`);
};
