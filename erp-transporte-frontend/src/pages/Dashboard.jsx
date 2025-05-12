import { useNavigate } from 'react-router-dom';


const Dashboard = () => {
    const navigate = useNavigate();
  
    return (
      <div>
        <h1>Dashboard</h1>
        <button onClick={() => navigate('/clientes')}>Ir para Clientes</button>
        <button onClick={() => navigate('/veiculos')}>Ir para Veiculos</button>
      </div>
    );
  };








export default Dashboard;