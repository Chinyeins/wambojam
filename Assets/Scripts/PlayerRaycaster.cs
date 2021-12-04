using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycaster : MonoBehaviour
{
  public Color OutlineColor = Color.yellow;
  public float OutlineWidth = 5f;
  GameObject lastTarget;
  void Update()
  {
    gameObject.layer = 2;
    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, 100))
    {
      GameObject target = hit.collider.gameObject;

      handleInteract(target);

      if (target == lastTarget) return;

      if (target.tag == "Interactive")
      {
        AddOrEnableOutline(target);
      }
      else
      {
        if (lastTarget?.tag == "Interactive")
        {
          DisableOutline(lastTarget);
        }
      }
      lastTarget = target;
    }
  }

  void AddOrEnableOutline(GameObject target)
  {
    Outline outline;
    if (target.GetComponent<Outline>() != null)
    {
      outline = target.GetComponent<Outline>();
    }
    else
    {
      outline = target.AddComponent<Outline>();
    }

    outline.enabled = true;
    outline.OutlineMode = Outline.Mode.OutlineAll;
    outline.OutlineColor = OutlineColor;
    outline.OutlineWidth = OutlineWidth;
  }

  void DisableOutline(GameObject target)
  {
    var outline = target.GetComponent<Outline>();
    if (outline) outline.enabled = false;
  }

  void handleInteract(GameObject target)
  {
    if (target.tag == "Interactive" && Input.GetButtonDown("Fire1"))
    {
      // general interaction - can be removed if we don't want it
      target.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

      //snipper interaction
      if (target.GetComponent<Snippet>() != null)
      {
        // do something
        Snippet snippet = gameObject.GetComponent<Snippet>();
        GameObject.Find("GameState").GetComponent<GameStateManager>().collectInventoryItem(snippet);
      }
    }
  }
}


