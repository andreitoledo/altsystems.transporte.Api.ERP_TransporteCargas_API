import api from './api';

export const getCnpjByCliente = async (clienteId) => {
  const { data } = await api.get(`/Cliente/${clienteId}/Cnpj`);
  return data;
};

export const createCnpj = async (clienteId, cnpjData) => {
  const { data } = await api.post(`/Cliente/${clienteId}/Cnpj`, cnpjData);
  return data;
};

export const updateCnpj = async (clienteId, cnpjData) => {
  const { data } = await api.put(`/Cliente/${clienteId}/Cnpj`, cnpjData);
  return data;
};

export const deleteCnpj = async (clienteId) => {
  await api.delete(`/Cliente/${clienteId}/Cnpj`);
};
