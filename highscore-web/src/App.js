import logo from './logo.svg';
import './App.css';
import HighscoreBlock from './highscoreBlock';
import { Connector } from 'mqtt-react-hooks';
import Status from './Status';

function App() {
  

  return (
    <div>
      <Connector brokerUrl='mqtt://test.mosquitto.org:8081'>
        <Status />
      </Connector>
    </div>

  );
}

export default App;
