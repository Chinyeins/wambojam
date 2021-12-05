using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscares : MonoBehaviour
{
    private System.DateTime lastJumpscare = System.DateTime.Now;
    private long nextJumpscareSeconds = 0;
    

    private long genNextJumpscareSeconds()
    {
        return new System.Random().Next(30, 60);
    }

    private void jumpingJackFlash()
    {
        int countJumpScarePosition = new System.Random().Next(0, GameObject.Find("LocalJumpscarePositions").GetComponent<LocalJumpscarePositionHolder>().jumpscarePositions.Count - 1);
        GameObject jumpscarePosition = GameObject.Find("LocalJumpscarePositions").GetComponent<LocalJumpscarePositionHolder>().jumpscarePositions[countJumpScarePosition];

        int countJumpScareObject = new System.Random().Next(0, GameObject.Find("LocalJumpscareObjectHolder").GetComponent<LocalJumpscareObjectHolder>().jumpscareObjects.Count - 1);
        GameObject jumpscareObject = GameObject.Find("LocalJumpscareObjectHolder").GetComponent<LocalJumpscareObjectHolder>().jumpscareObjects[countJumpScarePosition];

        GameObject jumpScareObjectInstance=GameObject.Instantiate(jumpscareObject);

        jumpScareObjectInstance.transform.position = jumpscarePosition.transform.position;
        jumpScareObjectInstance.GetComponent<AudioSource>().PlayOneShot(jumpScareObjectInstance.GetComponent<AudioSource>().clip);
        jumpScareObjectInstance.GetComponent<Animator>().SetTrigger("walkTrigger");
        AnimationClip clip = jumpScareObjectInstance.GetComponent<Animator>().runtimeAnimatorController.animationClips[0];

        StartCoroutine(WaitForAnimation(clip, jumpScareObjectInstance));
        
    }


    // Start is called before the first frame update
    void Start()
    {
        lastJumpscare = System.DateTime.Now;
        nextJumpscareSeconds = genNextJumpscareSeconds();
    }

    private IEnumerator WaitForAnimation(AnimationClip animation, GameObject jsi)
    {
        System.DateTime start = DateTime.Now;
        do
        {
            yield return null;
        } while ((DateTime.Now-start).TotalSeconds<animation.length);
        GameObject.Destroy(jsi);
    }


    // Update is called once per frame
    void Update()
    {
        if((System.DateTime.Now-lastJumpscare).TotalSeconds>nextJumpscareSeconds)
        {
            lastJumpscare = System.DateTime.Now;
            nextJumpscareSeconds = genNextJumpscareSeconds();
            jumpingJackFlash();
        }
    }
}
