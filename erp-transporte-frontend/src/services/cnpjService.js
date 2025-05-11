import api from './api';

export const getCnpjByCliente = async (clienteId) => {
  const { data } = await api.get(`/Cliente/${clienteId}/Cnpj`);
  return data;
};

export const createOrUpdateCnpj = async (clienteId, cnpjData) => {
  const { data } = await api.post(`/Cliente/${clienteId}/Cnpj`, cnpjData);
  return data;
};

export const deleteCnpj = async (clienteId) => {
  await api.delete(`/Cliente/${clienteId}/Cnpj`);
};
