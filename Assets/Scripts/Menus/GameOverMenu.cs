using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject canvas;

    private void Start()
    {
        if(this.canvas) {
            //initally hide game over menu
            this.canvas.SetActive(false);
        }
    }

    public void LoadMainMenu() {
        Debug.Log("Loading main menu...");

        SceneManager.LoadScene(0);
    }

    public void showGameOver() {
        if(canvas != null) {
            this.canvas.SetActive(true);

            this.disableUserInput();
        }
    }


    protected void disableUserInput() {
        //TODO: Disable user input
    }
    
}
