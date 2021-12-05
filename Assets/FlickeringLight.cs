using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private Animation anim;
    public float PlayAnimationEverySeconds = 10f;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    /// <summary>
    /// Play animation - flickering, randomly every X seconds
    /// </summary>
    private void playAnimation() {
        if(PlayAnimationEverySeconds > 1.0f) {
            this.anim.Play();
            Invoke("playAnimation", PlayAnimationEverySeconds);
        } 
    }





}
