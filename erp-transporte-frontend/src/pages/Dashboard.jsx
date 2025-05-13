import { useNavigate } from 'react-router-dom';


const Dashboard = () => {
    const navigate = useNavigate();
  
    return (
      <div>
        <h1>Dashboard</h1>
        <button onClick={() => navigate('/clientes')}>Clientes</button>
        <button onClick={() => navigate('/veiculos')}>Veiculos</button>
        <button onClick={() => navigate('/motoristas')}>Motoristas</button>
        <button onClick={() => navigate('/viagens')}>Viagens</button>
      </div>
    );
  };








export default Dashboard;