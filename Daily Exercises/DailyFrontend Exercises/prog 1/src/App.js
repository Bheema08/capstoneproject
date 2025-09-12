import logo from './logo.svg';
import './App.css';
import First from './components/first/first';
import Second from './components/second/second';
import Third from './components/third/third';
import ButtonEx from './components/buttonx/buttonx';
import Four from './components/four/four';
import Five from './components/five/five';
import Sixth from './components/sixth/sixth';
import Six from './components/sixth/sixth';
import Seven from './components/seven/seven';
import Eight from './components/eight/eight';

function App() {
  return (
    <div className="App">
      <p> Welcome to react programming </p>
      <p>
        <First/>
      </p>
      <p>
        <Second/>
      </p>
      <p>
        <Third firstName="BheemaDevadatta" lastName="Bopparaju" company="Wipro" />
      </p>
      <p>
        <ButtonEx/>
      </p>
      <p>
        <Four/>
      </p>
      <p>
        <Five/>
      </p>
      <p>
        <Sixth/>
      </p>
      <p>
        <Seven/>
        </p>      
        <p>
          <Eight/>
          </p>  
    </div>
  );
}

export default App;
