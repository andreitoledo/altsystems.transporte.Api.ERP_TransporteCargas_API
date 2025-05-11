import api from './api';

export const getDadosGeraisByCliente = async (clienteId) => {
  const { data } = await api.get(`/Cliente/${clienteId}/DadosGerais`);
  console.log('DADOS GERAIS =>', data); // <== DEBUG
  return data;
};

export const createDadosGerais = async (clienteId, dados) => {
  const { data } = await api.post(`/Cliente/${clienteId}/DadosGerais`, dados);
  return data;
};

export const updateDadosGerais = async (clienteId, id, dados) => {
  const { data } = await api.put(`/Cliente/${clienteId}/DadosGerais/${id}`, dados);
  return data;
};

export const deleteDadosGerais = async (clienteId, id) => {
  await api.delete(`/Cliente/${clienteId}/DadosGerais/${id}`);
};
