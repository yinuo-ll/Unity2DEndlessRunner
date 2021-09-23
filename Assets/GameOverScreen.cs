using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {
    public Text pointsText;

    public void Setup(float score) {
        gameObject.SetActive(true);
        pointsText.text = score.ToString("F2") + " M";
    }

    // Temporary test function to allow button to restart the game
    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }

    public void TimerButton() {
        //implement transition to pomodoro timer
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
