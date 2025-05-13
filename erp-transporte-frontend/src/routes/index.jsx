import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import LoginPage from '../pages/LoginPage';
import Dashboard from '../pages/Dashboard';
import Clientes from '../pages/Clientes';
import ClienteDetalhe from '../pages/ClienteDetalhes';
import Veiculos from '../pages/Veiculos'; 
import Motoristas from '../pages/Motoristas';
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

      {/* <Route path="/clientes" element={<PrivateRoute><Clientes /></PrivateRoute>} /> */}
      <Route path="/clientes" element={<Clientes />} />
      {/* <Route path="/cliente/:id/detalhe" element={<PrivateRoute><ClienteDetalhe /></PrivateRoute>} /> */}
      <Route path="/clientes/:id/detalhe" element={<ClienteDetalhe />} />
      {/* <Route path="/veiculos" element={<PrivateRoute><Veiculos /></PrivateRoute>} /> */}
      <Route path="/veiculos" element={<Veiculos />} />
      <Route path="/motoristas" element={<Motoristas />} />

    </Routes>
  </Router>
);

export default AppRoutes;
