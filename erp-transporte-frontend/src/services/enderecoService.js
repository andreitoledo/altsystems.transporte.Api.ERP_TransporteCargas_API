import api from './api';

export const getEnderecosByCliente = async (clienteId) => {
  const response = await api.get(`/Cliente/${clienteId}/Enderecos`);
  return response.data;
};
