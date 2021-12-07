using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Jumpscares : MonoBehaviour
{
    private System.DateTime lastJumpscare = System.DateTime.Now;
    private long nextJumpscareSeconds = 0;
    private bool running = false;
    private bool blubb = false;

    private long genNextJumpscareSeconds()
    {
        return new System.Random().Next(30, 60);
    }

    private void jumpingJackFlash()
    {
       

        running = true;


        //jumpScareObjectInstance.GetComponent<NavMeshAgent>().enabled = true;
        //!!!        jumpScareObjectInstance.GetComponent<AudioSource>().PlayOneShot(jumpScareObjectInstance.GetComponent<AudioSource>().clip);
        //jumpScareObjectInstance.GetComponent<NavMeshAgent>().destination=jumpscarePosition.GetComponent<LocalJumpscarePositionHolder>().jumpscarePositions[0].transform.position;
      //  jumpScareObjectInstance.GetComponent<NavMeshAgent>().Move( jumpscarePosition.GetComponent<LocalJumpscarePositionHolder>().jumpscarePositions[0].transform.position);
        //jumpScareObjectInstance.GetComponent<Animator>().SetTrigger("walkTrigger");
        //AnimationClip clip = jumpScareObjectInstance.GetComponent<Animator>().runtimeAnimatorController.animationClips[0];

        //StartCoroutine(WaitForAnimation(clip, jumpScareObjectInstance));

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

    GameObject jumpScareObjectInstance;
    // Update is called once per frame
    void Update()
    {
        if((System.DateTime.Now-lastJumpscare).TotalSeconds>nextJumpscareSeconds && GameObject.Find("GameState").GetComponent<GameStateManager>().snippetFound)
        {
            lastJumpscare = System.DateTime.Now;
            nextJumpscareSeconds = genNextJumpscareSeconds();
            jumpingJackFlash();
        }
        else if(!GameObject.Find("GameState").GetComponent<GameStateManager>().snippetFound)
        {
            lastJumpscare = System.DateTime.Now;
            nextJumpscareSeconds = genNextJumpscareSeconds();
        }

        if(running)
        {
            
            int countJumpScarePosition = new System.Random().Next(0, GameObject.Find("LocalJumpscarePositions").GetComponent<LocalJumpscarePositionHolder>().jumpscarePositions.Count - 1);
            GameObject jumpscarePosition = GameObject.Find("LocalJumpscarePositions").GetComponent<LocalJumpscarePositionHolder>().jumpscarePositions[countJumpScarePosition];
            if (!blubb)
            {
                
                

                int countJumpScareObject = new System.Random().Next(0, GameObject.Find("LocalJumpscareObjectHolder").GetComponent<LocalJumpscareObjectHolder>().jumpscareObjects.Count - 1);
                GameObject jumpscareObject = GameObject.Find("LocalJumpscareObjectHolder").GetComponent<LocalJumpscareObjectHolder>().jumpscareObjects[countJumpScarePosition];

                jumpScareObjectInstance = GameObject.Instantiate(jumpscareObject);
                jumpscarePosition.GetComponent<GhostObject>().ghostObject = jumpScareObjectInstance;
                //jumpScareObjectInstance.GetComponent<NavMeshAgent>().enabled = false;
                jumpScareObjectInstance.transform.position = jumpscarePosition.transform.position;
                blubb = true;
            }            
            {
                if (jumpScareObjectInstance != null)
                {
                    jumpScareObjectInstance.transform.position = Vector3.Lerp(jumpScareObjectInstance.transform.position, jumpscarePosition.GetComponent<LocalJumpscarePositionHolder>().jumpscarePositions[0].transform.position, 0.001f);
                    if (jumpScareObjectInstance.transform.position == jumpscarePosition.GetComponent<LocalJumpscarePositionHolder>().jumpscarePositions[0].transform.position)
                    {
                        GameObject.Destroy(jumpScareObjectInstance);
                        blubb = false;
                        running = false;
                    }
                }
            }
        }
        
    }
}
