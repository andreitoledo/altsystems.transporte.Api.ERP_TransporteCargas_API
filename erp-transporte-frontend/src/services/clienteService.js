import api from './api';

export const getClientes = async () => {
  const response = await api.get('/Cliente');
  return response.data;
};

export const createCliente = async (cliente) => {
  const response = await api.post('/Cliente', cliente);
  return response.data;
};

export const getClienteById = async (id) => {
  const response = await api.get(`/Cliente/${id}`);
  return response.data;
};

export const updateCliente = async (id, cliente) => {
  const response = await api.put(`/Cliente/${id}`, cliente);
  return response.data;
};

export const deleteCliente = async (id) => {
  await api.delete(`/Cliente/${id}`);
};
