using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public void LoadMainMenu() {
        Debug.Log("Loading main menu...");

        SceneManager.LoadScene("MainMenu");
    }
    
}
