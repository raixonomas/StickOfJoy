import logo from './logo.svg';
import './App.css';
import { useEffect, useState } from 'react';

function App() {
 /*"altbeast", "ddonpach", "ffight", "frogger", , "goldenaxe", "mmancp2u", "pacman", "raiden2" */
  const timeout = 1000
  const gameArray = ["galaga"]
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

  async function CallApi(gameName)
  {
    const response = await fetch(`https://10.4.1.202:7166/ControllerGame/${gameName}`, {
      method: 'GET',
      headers: {'Content-Type': 'application/json'}
    }).then((body) => body.json())
    .then((c) => console.log(c));
  }

  return (
    <div>
      
    </div>

  );
}

export default App;
