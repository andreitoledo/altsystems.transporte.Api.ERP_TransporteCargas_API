import api from './api';

export const getContatosByCliente = async (clienteId) => {
  const response = await api.get(`/Cliente/${clienteId}/Contato`);
  return response.data;
};

export const createContato = async (clienteId, contato) => {
  const response = await api.post(`/Cliente/${clienteId}/Contato`, contato);
  return response.data;
};

export const updateContato = async (clienteId, id, contato) => {
  const response = await api.put(`/Cliente/${clienteId}/Contato/${id}`, contato);
  return response.data;
};

export const deleteContato = async (clienteId, id) => {
  await api.delete(`/Cliente/${clienteId}/Contato/${id}`);
};
