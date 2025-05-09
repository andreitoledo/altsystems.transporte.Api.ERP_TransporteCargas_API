import { Grid, TextField } from '@mui/material';

const DadosGerais = () => (
  <Grid container spacing={2}>
    <Grid item xs={6}>
      <TextField fullWidth label="Razão Social" />
    </Grid>
    <Grid item xs={6}>
      <TextField fullWidth label="CNPJ" />
    </Grid>
    <Grid item xs={6}>
      <TextField fullWidth label="Inscrição Estadual" />
    </Grid>
    <Grid item xs={6}>
      <TextField fullWidth label="Data de Cadastro" type="date" InputLabelProps={{ shrink: true }} />
    </Grid>
  </Grid>
);

export default DadosGerais;