using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    public GameState gameState;

    public void collectInventoryItem(InventoryItem inventoryItem)
    {
        gameState.inventory.inventoryItems.Add(inventoryItem);

        if(isPictureFinished()) {
            nextScene();
        }
    }

    public void insertSnippetIntoPicture(InventoryItem inventoryItem)
    {
        gameState.inventory.inventoryItems.Remove(inventoryItem);
        gameState.pictureOfMother.snippets.Add((Snippet)inventoryItem);
    }

    private bool isPictureFinished()
    {
        bool allFound = true;
        foreach(SnippetType snippetTypeRequired in gameState.pictureOfMother.snippetsRequired)
        {
            bool snippetFound = false;
            foreach(Snippet snippet in gameState.pictureOfMother.snippets)
            {
                if(snippet.snippetType == snippetTypeRequired)
                {
                    snippetFound = true;
                    break;
                }                
            }
            if (!snippetFound)
            {
                allFound = false;
                break;
            }
        }
        return allFound;
    }

    private void nextScene()
    {
        gameState.iteration++;
        LevelData levelData = GameObject.Find("LevelData").GetComponent<LevelData>();
        gameState.pictureOfMother.snippetsRequired = new List<SnippetType>();
        gameState.pictureOfMother.snippets = new List<Snippet>();
        
        foreach(SnippetType snippetType in levelData.snippetTypesRequired[gameState.iteration])
        {
            gameState.pictureOfMother.snippetsRequired.Add(snippetType);
        }

        SceneManager.LoadScene("MainLevel");
    }

    private void gameOver() {
        SceneManager.LoadScene("GameOver");
    }



    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}
