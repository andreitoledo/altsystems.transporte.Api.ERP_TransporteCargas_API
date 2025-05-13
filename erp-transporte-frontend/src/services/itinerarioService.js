import api from './api';

export const getItinerariosByViagem = async (viagemId) => {
  const response = await api.get('/Itinerario');
  return response.data.filter(i => i.viagemId === parseInt(viagemId));
};

export const createItinerario = async (itinerario) => {
  await api.post('/Itinerario', itinerario);
};

export const updateItinerario = async (id, itinerario) => {
  await api.put(`/Itinerario/${id}`, itinerario);
};

export const deleteItinerario = async (id) => {
  await api.delete(`/Itinerario/${id}`);
};
