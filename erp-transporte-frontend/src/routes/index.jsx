import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import LoginPage from '../pages/LoginPage';
import Dashboard from '../pages/Dashboard';
import Clientes from '../pages/Clientes';
import ClienteDetalhe from '../pages/ClienteDetalhes';
import PrivateRoute from './PrivateRoute';

const AppRoutes = () => (
  <Router>
    <Routes>
      <Route path="/" element={<Navigate to="/login" />} />
      <Route path="/login" element={<LoginPage />} />
      <Route path="/dashboard" element={
        <PrivateRoute>
          <Dashboard />
        </PrivateRoute>
      } />
      <Route path="/clientes" element={<PrivateRoute><Clientes /></PrivateRoute>} />
      <Route path="/cliente/:id/detalhe" element={<PrivateRoute><ClienteDetalhe /></PrivateRoute>} />
    </Routes>
  </Router>
);

export default AppRoutes;
