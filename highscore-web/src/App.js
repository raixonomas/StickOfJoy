import logo from './logo.svg';
import './App.css';
import { useEffect, useState } from 'react';
import HighscoreBlock from './highscoreBlock';

function App() {
 /*"altbeast", "ddonpach", "ffight", "frogger", , "goldenaxe", "mmancp2u", "pacman", "raiden2" */
  const timeout = 15000
  const gameArray = ["galaga","altbeast", "ddonpach", "ffight", "frogger", "goldenaxe", "mmancp2u", "pacman", "raiden2"]
  const [gameNameAndHighscore, setGameNameAndHighscore] = useState(
  {
    "Galaga" : "",
    "Altered Beast" : "",
    "DoDonPachi" : "",
    "FinalFight" : "",
    "Frogger" : "",
    "GoldenAxe" : "",
    "Mega Man 2" : "",
    "Pac-Man" : "",
    "Raiden2" : "",
  })

  const handleChange = (e) => {
    console.log(e) 
      setGameNameAndHighscore(game => (
          {     
              ...game,
              ...e
          }
    ));
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
    const response = await fetch(`http://10.4.1.237:3000/ControllerGame/${gameName}`, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "DELETE, POST, GET, OPTIONS",
        "Access-Control-Allow-Headers": "Content-Type",
        'Access-Control-Allow-Credentials': 'true'
      }
    }).then((body) => body.json())
    .then((c) => {      
      switch(gameName){
        case "galaga" : {
          var temp = {}
          temp["Galaga"] = c["content"]
          handleChange(temp)
          break;
        }
        case "altbeast" : {
          var temp = {}
          temp["Altered Beast"] = c["content"]
          handleChange(temp)
          break;
        }
        case "ddonpach" : {
          var temp = {}
          temp["DoDonPachi"] = c["content"]
          handleChange(temp)
          break;
        }
        case "ffight" : {
          var temp = {}
          temp["FinalFight"] = c["content"]
          handleChange(temp)
          break;
        }
        case "frogger" : {
          var temp = {}
          temp["Frogger"] = c["content"]
          handleChange(temp)
          break;
        }
        case "goldenaxe" : {
          var temp = {}
          temp["GoldenAxe"] = c["content"]
          handleChange(temp)
          break;
        }
        case "mmancp2u" : {
          var temp = {}
          temp["Mega Man 2"] = c["content"]
          handleChange(temp)
          break;
        }
        case "pacman" : {
          var temp = {}
          temp["Pac-Man"] = c["content"]
          handleChange(temp)
          break;
        }
        case "raiden2" : {
          var temp = {}
          temp["Raiden2"] = c["content"]
          handleChange(temp)
          break;
        }

      }
    });
  }

  return ( 
    <div className='main'>
      {
        Object.keys(gameNameAndHighscore).map(element => {
          console.log(gameNameAndHighscore)
          return(
            <div className='container'>
              <HighscoreBlock gameName = {element} highscore = {gameNameAndHighscore[element]}/>
            </div>           
          )
        })
      }
    </div>

  );
}

export default App;
