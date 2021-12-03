using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycaster : MonoBehaviour
{
  void FixedUpdate()
  {

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, 100))
    {
      if (hit.collider.gameObject.tag == "Interactive")
      {
        Debug.DrawLine(ray.origin, hit.point);
        Debug.Log("Interactive Hit");
        hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
      }
    }
  }
}
