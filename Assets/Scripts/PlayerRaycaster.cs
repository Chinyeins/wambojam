using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycaster : MonoBehaviour
{

  GameObject lastTarget;
  void FixedUpdate()
  {
    gameObject.layer = 2;
    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, 100))
    {
      GameObject target = hit.collider.gameObject;

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

    target.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

    outline.enabled = true;
    outline.OutlineMode = Outline.Mode.OutlineAll;
    outline.OutlineColor = Color.yellow;
    outline.OutlineWidth = 5f;
  }

  void DisableOutline(GameObject target)
  {
    var outline = target.GetComponent<Outline>();
    if (outline) outline.enabled = false;
  }
}


