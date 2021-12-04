using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscares : MonoBehaviour
{
    private System.DateTime lastJumpscare = System.DateTime.Now;
    private long nextJumpscareSeconds = 0;

    private long genNextJumpscareSeconds()
    {
        return 0;
    }

    private void jumpingJackFlash()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((System.DateTime.Now-lastJumpscare).TotalSeconds>nextJumpscareSeconds)
        {
            nextJumpscareSeconds = genNextJumpscareSeconds();
            jumpingJackFlash();
        }
    }
}
