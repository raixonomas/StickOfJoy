import React from 'react';
import Card from 'react-bootstrap/Card';
import "./highscoreCSS.css"

function HighscoreBlock(props) {
    let label = <label>{props.highscore.replaceAll("@", "\n")}</label>
    return (
    <Card style={{ width: '18rem' }}>
        <Card.Body>
        <h1>{props.gameName}</h1>                 
            <Card.Text className='highscoreLine'>
                {props.highscore.split("@").map(function(item, index){
                    return(
                        <span key={index}>
                            {item}
                            <br/>
                        </span>)
                })}
            </Card.Text>
        </Card.Body>  
      </Card>
    );
}

export default HighscoreBlock