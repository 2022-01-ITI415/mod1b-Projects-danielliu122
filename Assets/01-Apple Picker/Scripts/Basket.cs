using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT; 


    void Start() {
        // Find a reference to the ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text Component of that GameO
        scoreGT = scoreGO.GetComponent<Text>();

        // Set the starting number of points to
        scoreGT.text = "0";
    }

    void Update () {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition; // 1
        
        // The Camera's z position sets the how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z; // 2

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D =
        Camera.main.ScreenToWorldPoint( mousePos2D ); // 3

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter( Collision coll ) {
         // 2

        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject; // 3

        if ( collidedWith.tag == "Apple" ) { // 4
            Destroy( collidedWith );
            Debug.Log("Collided with apple");


            // Parse the text of the scoreGT 
            int score = int.Parse( scoreGT.text);

            // Add points for catching the apple
            score += 100;

            // Convert the score back to a string
            scoreGT.text = score.ToString();

            Debug.Log("Highscore test "+ HighScore.score);

            // Track the high score
            if (score > HighScore.score) {
                Debug.Log("Detected new high score; setting new high score ");
                HighScore.score = score;
            }
        }
    }
}
