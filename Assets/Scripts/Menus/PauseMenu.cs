using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if(PauseMenuCanvas != null) {
            PauseMenuCanvas.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetButton("Cancel")) {
            //TODO: FIX this! make delay 
            toggleMenu();
        }
    }


    public void LoadMainMenu() {
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene(0);
    }


    public void toggleMenu() {
        bool isMenuActive = PauseMenuCanvas.activeSelf;

        PauseMenuCanvas.SetActive(!isMenuActive);
    }
}
