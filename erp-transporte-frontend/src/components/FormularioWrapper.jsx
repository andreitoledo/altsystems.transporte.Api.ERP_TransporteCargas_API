import { Dialog, DialogTitle, DialogContent, DialogActions, Box, Paper } from '@mui/material';
import Button from '@mui/material/Button';

const FormularioWrapper = ({
  modo = 'dialog', // 'inline' ou 'dialog'
  aberto,
  titulo = 'Formulário',
  onFechar,
  onSalvar,
  children
}) => {
  if (modo === 'inline') {
    return (
      <Paper elevation={3} sx={{ p: 2, mb: 2 }}>
        <Box sx={{ mb: 2 }}>
          <strong>{titulo}</strong>
        </Box>
        {children}
        <Box sx={{ mt: 2, display: 'flex', gap: 2 }}>
          <Button variant="contained" onClick={onSalvar}>Salvar</Button>
          {onFechar && <Button onClick={onFechar}>Cancelar</Button>}
        </Box>
      </Paper>
    );
  }

  return (
    <Dialog open={aberto} onClose={onFechar} maxWidth="md" fullWidth>
      <DialogTitle>{titulo}</DialogTitle>
      <DialogContent dividers>{children}</DialogContent>
      <DialogActions>
        <Button onClick={onFechar}>Cancelar</Button>
        <Button variant="contained" onClick={onSalvar}>Salvar</Button>
      </DialogActions>
    </Dialog>
  );
};

export default FormularioWrapper;
