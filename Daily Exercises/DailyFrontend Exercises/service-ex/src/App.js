import logo from './logo.svg';
import './App.css';
import UserShow from './components/usershow/usershow';
import UserSearch from './components/usersearch/usersearch';
import EmploySearch from './components/employsearch/employsearch';
import EmployShow from './components/employshow/employshow';

function App() {
  return (
    <div className="App">
      <UserShow/>
      <UserSearch/>
      
      <EmployShow/>
      <EmploySearch/>
    </div>
  );
}

export default App;
