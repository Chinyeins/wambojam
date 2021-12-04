using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
  float minDelay = 5;
  float maxDelay = 30;
  float minLight = .03f;
  float maxLight = 0.1f;
  void Start()
  {
    StartCoroutine(PlayLightning());
  }

  IEnumerator PlayLightning()
  {
    bool isActive = transform.GetChild(0).gameObject.activeSelf;
    float randomAmount = Random.Range(1, 3) * 2;

    Debug.Log("Amount" + randomAmount);

    for (int i = 0; i < randomAmount; i += 1)
    {
      isActive = !isActive;
      float randomLight = Random.Range(minLight, maxLight);
      transform.GetChild(0).gameObject.SetActive(isActive);
      yield return new WaitForSeconds(randomLight);
    }

    float randomTime = Random.Range(minDelay, maxDelay);
    yield return new WaitForSeconds(randomTime);

    StartCoroutine(PlayLightning());
  }
}
