using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
  public GameObject Ghost;

  public float minDelay = 5;
  public float maxDelay = 30;
  public float minLight = .03f;
  public float maxLight = 0.1f;
  void Start()
  {
    Ghost.gameObject.SetActive(false);
    StartCoroutine(PlayLightning());
  }

  IEnumerator PlayLightning()
  {
    bool isActive = transform.GetChild(0).gameObject.activeSelf;
    float randomAmount = Random.Range(1, 3) * 2;

    for (int i = 0; i < randomAmount; i += 1)
    {
      isActive = !isActive;
      float randomLight = Random.Range(minLight, maxLight);
      Ghost.gameObject.SetActive(isActive);
      transform.GetChild(0).gameObject.SetActive(isActive);
      yield return new WaitForSeconds(randomLight);
    }

    float randomTime = Random.Range(minDelay, maxDelay);
    yield return new WaitForSeconds(randomTime);

    StartCoroutine(PlayLightning());
  }
}
