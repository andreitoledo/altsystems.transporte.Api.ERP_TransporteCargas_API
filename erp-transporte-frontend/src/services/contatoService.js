import api from './api';

export const getContatosByCliente = async (clienteId) => {
  const response = await api.get(`/Cliente/${clienteId}/Contatos`);
  return response.data;
};
