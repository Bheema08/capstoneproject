import logo from './logo.svg';
import './App.css';
import EmployAdd from './components/employAdd/employAdd';
import EmploySearch from './components/employsearch/employsearch';
import EmployShow from './components/employshow/employshow';

function App() {
  return (
    <div className="App">
     <EmployAdd/>
     <EmploySearch/>
     <EmployShow/>
    </div>
  );
}

export default App;
