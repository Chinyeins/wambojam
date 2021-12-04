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
             gameOver();
         }
    }

    public void insertSnippetIntoPicture(InventoryItem inventoryItem)
    {
        gameState.inventory.inventoryItems.Remove(inventoryItem);
        gameState.pictureOfMother.snippets.Add((Snippet)inventoryItem);
    }

    private bool isPictureFinished()
    {
        return gameState.pictureOfMother.snippets.Count == 6;
    }



    private void gameOver() {
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
