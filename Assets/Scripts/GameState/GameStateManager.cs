using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    public GameState gameState;

    public void collectInventoryItem(Snippet snippet)
    {
        if (!gameState.pictureOfMother.snippets.Contains(snippet))
            gameState.pictureOfMother.snippets.Add(snippet);

        if (isPictureFinished())
        {
            gameOver();
        }
    }

    private bool isPictureFinished()
    {
        return gameState.pictureOfMother.snippets.Count == 6;
    }



    private void gameOver()
    {
        SceneManager.LoadScene("GameOver");
    }



    // Start is called before the first frame update
    void Start()
    {
        gameState = new GameState();
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}
