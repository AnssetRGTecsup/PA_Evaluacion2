using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;

    [SerializeField] private float distance = 0f;

    private void Update() {
        distance += Time.deltaTime;

        if(distance >= 1){
            score += (int) distance;
            distance = 0f;
        }
    }
}
