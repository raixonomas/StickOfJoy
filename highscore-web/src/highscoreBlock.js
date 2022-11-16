import React from 'react';

function HighscoreBlock(props) {

    return (
      <div className='highscoreBlock'>
        <label>{props.gameName}</label>
        {
            props.highscoreArray.map((element, key) => {             
                return(
                    <div className='highscoreLine'>
                        <label>{element}</label>
                    </div>
                )
            })
        }       
      </div>
    );
}

export default HighscoreBlock