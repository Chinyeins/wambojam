using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startGame() {
        Debug.Log("Loading MainLevel...");
        SceneManager.LoadScene(1);
    }

    public void exitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
