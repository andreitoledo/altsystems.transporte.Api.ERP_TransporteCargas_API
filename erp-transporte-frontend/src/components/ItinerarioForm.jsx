import { useEffect, useState } from 'react';
import { Grid, TextField, Button, Box } from '@mui/material';

const ItinerarioForm = ({ itinerarioData = {}, onSubmit, onCancel }) => {
  const [form, setForm] = useState({
    local: '',
    horaPrevista: '',
    viagemId: 0
  });

  useEffect(() => {
    if (itinerarioData) {
      setForm({
        ...form,
        ...itinerarioData,
        horaPrevista: itinerarioData.horaPrevista?.substring(0, 16) || '',
      });
    }
    // eslint-disable-next-line
  }, [itinerarioData]);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = () => {
    onSubmit({ ...form, viagemId: parseInt(form.viagemId) });
  };

  return (
    <Box sx={{ mb: 2 }}>
      <Grid container spacing={2}>
        <Grid item xs={12} md={8}>
          <TextField
            name="local"
            label="Local"
            value={form.local}
            onChange={handleChange}
            fullWidth
          />
        </Grid>
        <Grid item xs={12} md={4}>
          <TextField
            name="horaPrevista"
            label="Hora Prevista"
            type="datetime-local"
            value={form.horaPrevista}
            onChange={handleChange}
            fullWidth
            InputLabelProps={{ shrink: true }}
          />
        </Grid>
        <Grid item xs={6}>
          <Button variant="contained" onClick={handleSubmit} fullWidth>
            Salvar
          </Button>
        </Grid>
        <Grid item xs={6}>
          {onCancel && (
            <Button onClick={onCancel} color="secondary" fullWidth>
              Cancelar
            </Button>
          )}
        </Grid>
      </Grid>
    </Box>
  );
};

export default ItinerarioForm;
