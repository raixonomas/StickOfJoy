import logo from './logo.svg';
import './App.css';
import { useEffect, useState } from 'react';

function App() {

  const timeout = 1000
  const gameArray = ["altbeast", "ddonpach", "ffight", "frogger", "galaga", "goldenaxe", "mmancp2u", "pacman", "raiden2"]
  var gameNameAndHighscore = 
  {
    "AlteredBeast" : "",
    "FinalFight" : "",
  }

  useEffect(() => {
    const interval = setInterval(() => {
      gameArray.forEach(element => {
        CallApi(element)
      }); 

    }, timeout);

    return () => {

      clearInterval(interval)  
    };
  }, [])

  function CallApi(gameName)
  {
    /*const response = await fetch(`/MQTT/Game/${gamename}`, {
      method: 'GET',
      headers: {'Content-Type': 'application/json'}
    })*/
  }

  return (
    <div>
      
    </div>

  );
}

export default App;
