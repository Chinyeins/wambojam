using System.Net.WebSockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

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

    private bool isOpen = false;

    public AudioClip ClueFoundSFX;


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


        //hide canvas initially
        this.canvas.SetActive(false);
    }


    private void Update()
    {
        if(Input.GetButtonDown("OpenInventory")) {

            if(this.isOpen) {
                this.hideScreen();
            } else {
                this.showScreen();
            }
        }
    }

    /// <summary>
    /// Start storytellling and show screen
    /// </summary>
    public void StartStoryTellingSequence() {
        this.audioSource = gameObject.GetComponent<AudioSource>();
        
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

        this.playClueFound();

        //play audio clip 
        AudioClip clip = this.currentItem.getAudio();
        float clipLen = 0;
        if(clip != null) {
            this.audioSource.PlayOneShot(clip);
            clipLen = clip.length;
        }

        //call even after clip is done playing
        Invoke("callAudioFinishedPlayEvent", clipLen);
    }

    private void playClueFound() {
        if(ClueFoundSFX != null) {
            this.audioSource.PlayOneShot(ClueFoundSFX);
        }
    }

    private void callAudioFinishedPlayEvent() {
        OnAudioFinishedPlaying.Invoke();
    }


    /// <summary>
    /// Display Screen. Starts Story Telling logic. Entrypoint for component.
    /// </summary>
    public void showScreen() {
        if(this.canvas && this.currentItem != null) {

            this.isOpen = true;

            this.canvas.SetActive(true);

            EventSystem.current.SetSelectedGameObject(this.canvas.gameObject);

            this.StartStoryTellingSequence();
        }
    }

    public void showScreen(StoryTellingItem item) {
        this.SetStoryTellingItem(item);
        this.showScreen();
    }

    /// <summary>
    /// Hide Screen. Exit point of component
    /// </summary>
    public void hideScreen() {
        if(this.canvas) {
            this.canvas.SetActive(false);

            this.isOpen = false;
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
