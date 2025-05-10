import { Grid, TextField } from '@mui/material';

const DadosGerais = ({ cliente }) => (
  <Grid container spacing={2}>
    <Grid item xs={6}>
      <TextField fullWidth label="Razão Social" value={cliente.nome} InputProps={{ readOnly: true }} />
    </Grid>
    <Grid item xs={6}>
      <TextField fullWidth label="CNPJ" value={cliente.cnpj || ''} InputProps={{ readOnly: true }} />
    </Grid>
    <Grid item xs={6}>
      <TextField fullWidth label="Inscrição Estadual" value={cliente.ie || ''} InputProps={{ readOnly: true }} />
    </Grid>
    <Grid item xs={6}>
      <TextField
        fullWidth
        label="Data de Cadastro"
        type="date"
        value={cliente.dataCadastro?.substring(0, 10) || ''}
        InputLabelProps={{ shrink: true }}
        InputProps={{ readOnly: true }}
      />
    </Grid>
  </Grid>
);

export default DadosGerais;
