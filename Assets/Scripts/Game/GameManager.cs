using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void ManagePoints(CandyController candyInstance, PlayerManager playerInstance){
        playerInstance.score += candyInstance.points;
    }

    public void ManageLife(EnemyController enemyInstance, PlayerManager playerInstance){
        int lives = playerInstance.lives;

        lives = Mathf.Clamp(lives - enemyInstance.damage,0,3);
        
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        playerInstance.lives = lives;
    }
}
