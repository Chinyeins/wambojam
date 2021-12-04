using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    public GameState gameState;

    public void collectInventoryItem(InventoryItem inventoryItem)
    {
        if(inventoryItem.inventoryItemType.isUnique)
        {
            if (gameState.inventory.inventoryItems.Contains(inventoryItem))
            {
                gameState.inventory.inventoryItems.Add(inventoryItem);
                switch(inventoryItem.inventoryItemType.inventoryTypeAction)
                {
                    case InventoryItemType.InventoryTypeAction.ITA_STORY:
                        new GameStateAction().startStoryTelling();
                        break;
                    case InventoryItemType.InventoryTypeAction.ITA_RESETLEVEL:
                        new GameStateAction().resetLevel();
                        break;                        
                    case InventoryItemType.InventoryTypeAction.ITA_NEWTARGET:
                        new GameStateAction().newElement();
                        break;
                }
            }
        }
        else
        {
            gameState.inventory.inventoryItems.Add(inventoryItem);
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



    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPictureFinished())
            nextScene();
    }
}
