using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycaster : MonoBehaviour
{

  private GameObject[] interactives;
  void FixedUpdate()
  {

    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
    RaycastHit hit;


    interactives = GameObject.FindGameObjectsWithTag("Interactive");

    foreach (GameObject interactive in interactives)
    {
      Outline outline = interactive.GetComponent<Outline>();
      if(outline) {
        outline.enabled = false;
      }
    }
    if (Physics.Raycast(ray, out hit, 100))
    {
      if (hit.collider.gameObject.tag == "Interactive")
      {
        Debug.DrawLine(ray.origin, hit.point);
        hit.collider.gameObject.GetComponent<Outline>().enabled = true;
        Debug.Log("Interactive Hit");
        hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
      }
    }
  }
}
