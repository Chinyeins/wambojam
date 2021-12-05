using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//song attribution: https://freemusicarchive.org/music/Metre#contact-artist
public class ImageRotator : MonoBehaviour
{
    // Start is called before the first frame update
    System.DateTime lastUpdate = System.DateTime.Now;
    int max = 0;
    bool pumpOut = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((System.DateTime.Now - lastUpdate).TotalMilliseconds > 100)
        {
            GameObject.Find("Image").GetComponent<Image>().CrossFadeColor(new Color(new System.Random().Next(256), new System.Random().Next(256), new System.Random().Next(256)), 1.0f, true, false);

            lastUpdate = System.DateTime.Now;
            Vector3 rot = GameObject.Find("Stulpen").transform.eulerAngles;
            rot.y -= 10.0f;
            GameObject.Find("Stulpen").transform.eulerAngles = rot;

            Vector3 scale = GameObject.Find("Stulpen").transform.localScale;
            if (pumpOut)
            {
                scale.y += 0.1f;
                scale.x += 0.1f;
            }
            else
            {
                scale.y -= 0.1f;
                scale.x -= 0.1f;
            }

            GameObject.Find("Stulpen").transform.localScale = scale;


            max++;

            if(max==30)
            {
                max = 0;
                if (pumpOut == false)
                    pumpOut = true;
                else
                    pumpOut = false;
            }
        }

    }
}
