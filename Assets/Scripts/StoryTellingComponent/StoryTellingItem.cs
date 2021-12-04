using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


/// <summary>
/// Data structure for story telling
/// 
/// Script needs to be added to storytelling Prefab
/// </summary>
public class StoryTellingItem : MonoBehaviour
{

    public AudioClip StoryAudioClip;

    public Snippet Snippet;

    public string StoryText;

    // Start is called before the first frame update
    void Start()
    {
        if(StoryAudioClip == null) {
            Debug.LogWarning("No Storytelling audio initalized. Please add Audio clip");
        }

        if(Snippet == null) {
            Debug.LogError("No Snippet initalized. Please add Audio Snipped");
        }

        if(StoryText.Length == 0) {
            Debug.LogError("No Storytelling Text initalized. Please add Story Telling Text");
        }
    }


    public AudioClip getAudio() {
        return this.StoryAudioClip;
    }

    public Sprite getImage() {
        return this.Snippet.getImage();
    }

    public string getText() {
        return this.StoryText;
    }
}
