import api from './api';

export const getInscricoesEstaduaisByCliente = async (clienteId) => {
  const { data } = await api.get(`/Cliente/${clienteId}/InscricoesEstaduais`);
  return data;
};

export const createInscricaoEstadual = async (clienteId, dto) => {
  const { data } = await api.post(`/Cliente/${clienteId}/InscricoesEstaduais`, dto);
  return data;
};

export const updateInscricaoEstadual = async (clienteId, id, dto) => {
  const { data } = await api.put(`/Cliente/${clienteId}/InscricoesEstaduais/${id}`, dto);
  return data;
};

export const deleteInscricaoEstadual = async (clienteId, id) => {
  await api.delete(`/Cliente/${clienteId}/InscricoesEstaduais/${id}`);
};
