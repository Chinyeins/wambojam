using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

  public GameObject Levels;
  public GameObject Player;

  public GameState gameState;
  public bool snippetFound = false;
  public void collectInventoryItem(Snippet snippet)
  {
    if (!gameState.pictureOfMother.snippets.Contains(snippet))
    {
      gameState.pictureOfMother.snippets.Add(snippet);
      EnableLevel(gameState.pictureOfMother.snippets.Count - 1);
      snippetFound = true;
    }

    if (isPictureFinished())
    {
       //gameOver();
    }
  }

  private bool isPictureFinished()
  {
    return gameState.pictureOfMother.snippets.Count == 6;
  }

  void EnableLevel(int id)
  {
    GameObject.FindGameObjectWithTag("Levels").transform.GetChild(id).gameObject.SetActive(true);
    ResetPlayer();
  }

  void ResetPlayer()
  {
    Player.transform.position = new Vector3(-3.3f, 5.5f, 66.4f);
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
