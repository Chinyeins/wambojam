using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Easteregg : MonoBehaviour
{
    private char[] cheat= { 'a', 'a', 'a', 'a', 'a' };
    private char[] iddqd = { 'i', 'd', 'd', 'q', 'd' };
    bool loaded = false;
    System.DateTime start = System.DateTime.Now;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("i"))
        {
            push('i');
        }
        else if(Input.GetKeyUp("d"))
        {
            push('d');
        }
        else if (Input.GetKeyUp("q"))
        {
            push('q');
        }
        test();

        if(loaded)
        {
            
            if((System.DateTime.Now-start).TotalSeconds>5)
            {
                cheat = new char[]{ 'a', 'a', 'a', 'a', 'a' };
                loaded = false;
                GameObject.Find("CameraHolder").GetComponent<CameraHolder>().camera.SetActive(true);
                SceneManager.UnloadScene("Easteregg");
            }
        }
    }

    private void test()
    {
        bool failed = false;
        for (int i = 0; i <= 4; i++)
            if (cheat[i] != iddqd[i])
                failed = true;
        if (!failed && !loaded)
        {
            start = System.DateTime.Now;
            loaded = true;
            SceneManager.LoadScene("Easteregg", LoadSceneMode.Additive);
            GameObject.Find("Player Camera").SetActive(false);
            

        }
    }

    private void push(char chr)
    {
        for (int i = 0; i < 4; i++)
            cheat[i] = cheat[i + 1];
        cheat[4] = chr;
    }
}
