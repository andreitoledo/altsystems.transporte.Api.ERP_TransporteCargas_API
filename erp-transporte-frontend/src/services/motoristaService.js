import api from './api';

export const getMotoristas = async () => {
  const { data } = await api.get('/Motorista');
  return data;
};

export const createMotorista = async (motorista) => {
  const { data } = await api.post('/Motorista', motorista);
  return data;
};

export const updateMotorista = async (id, motorista) => {
  const { data } = await api.put(`/Motorista/${id}`, motorista);
  return data;
};

export const deleteMotorista = async (id) => {
  await api.delete(`/Motorista/${id}`);
};
