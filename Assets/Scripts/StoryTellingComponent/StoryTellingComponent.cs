using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Story telling Component.
/// Handles showing story telling items to user.
/// </summary>
public class StoryTellingComponent : MonoBehaviour
{

    StoryTellingItem currentItem;
    public Text StoryText;

    public Image SnippedThumbnail;

    public GameObject canvas;

    protected AudioSource audioSource;

    public UnityEvent OnAudioFinishedPlaying;

    // Start is called before the first frame update
    void Start()
    {
        if(this.StoryText == null) {
            //need to add text object, where to show story text
            Debug.LogError("Story text ist not initalized in Story Component. Please init.");
        }

        if(this.SnippedThumbnail == null) {
            //set image object, which shows snipped image
            Debug.LogError("Snipped thumbnail needs to be init....");
        }

        this.audioSource = gameObject.GetComponent<AudioSource>();

        this.OnAudioFinishedPlaying = new UnityEvent();
    }


    private void Update()
    {
        if(Input.GetButtonDown("OpenInventory")) {
            this.showScreen();
        }
    }

    /// <summary>
    /// Start storytellling and show screen
    /// </summary>
    public void StartStoryTellingSequence() {
        if(currentItem == null) {
            Debug.LogError("Story telling item not initalized. Canot tell story...");

            return;
        }


        if(this.StoryText != null) {
            this.StoryText.text = this.currentItem.getText();
        }

        if(this.SnippedThumbnail != null) {
            this.SnippedThumbnail.sprite = this.currentItem.getImage();
        }

        //play audio clip 
        AudioClip clip = this.currentItem.getAudio();
        this.audioSource.PlayOneShot(clip);

        //call even after clip is done playing
        Invoke("callAudioFinishedPlayEvent", clip.length);
    }

    private void callAudioFinishedPlayEvent() {
        OnAudioFinishedPlaying.Invoke();
    }


    /// <summary>
    /// Display Screen. Starts Story Telling logic. Entrypoint for component.
    /// </summary>
    public void showScreen() {
        if(this.canvas) {
            this.canvas.SetActive(true);


            this.StartStoryTellingSequence();
        }
    }

    /// <summary>
    /// Hide Screen. Exit point of component
    /// </summary>
    public void hideScreen() {
        if(this.canvas) {
            this.canvas.SetActive(false);
        }

        this.audioSource.Stop();
    }


    public StoryTellingItem GetStoryTellingItem() {
        return this.currentItem;
    }

    public void SetStoryTellingItem(StoryTellingItem item) {
        this.currentItem = item;
    }
}
