import api from './api';

export const getEnderecosByCliente = async (clienteId) => {
  const response = await api.get(`/Cliente/${clienteId}/Endereco`);
  return response.data;
};

export const createEndereco = async (clienteId, endereco) => {
  const response = await api.post(`/Cliente/${clienteId}/Endereco`, endereco);
  return response.data;
};

export const updateEndereco = async (clienteId, id, endereco) => {
  const response = await api.put(`/Cliente/${clienteId}/Endereco/${id}`, endereco);
  return response.data;
};

export const deleteEndereco = async (clienteId, id) => {
  await api.delete(`/Cliente/${clienteId}/Endereco/${id}`);
};
