using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 50;

    void Awake() {      // 1

        // If the HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScore")) {   // 2
        
            score = PlayerPrefs.GetInt("HighScore");

        }

        // Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", score); // 3

    }


    void Update () {
        // Debug.Log("HighScore Update check");
        Text gt = this.GetComponent<Text>();

        // second part of code does not show ???
        
        gt.text = "High Score: "+ score.ToString();

        // Debug.Log("playerprefs getint check"+ PlayerPrefs.GetInt("HighScore").ToString());

        // Update HighScore in PlayerPrefs if necessary
        if (score > PlayerPrefs.GetInt("HighScore")) { // 4
            // Debug.Log("Update HighScore in PlayerPrefs?");
            PlayerPrefs.SetInt("HighScore", score);
            // Debug.Log("setting high score in playerprefs");
        }
    }
}
