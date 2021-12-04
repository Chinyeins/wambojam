using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject canvas;

    public string Story;

    private void Start()
    {
        
    }

    public void LoadMainMenu() {
        Debug.Log("Loading main menu...");

        SceneManager.LoadScene(0);
    }
    
}
