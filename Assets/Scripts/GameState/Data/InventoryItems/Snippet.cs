using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snippet : InventoryItem
{
    public SnippetType snippetType;

    public Sprite SnippedImage;


    public Sprite getImage() {
        return this.SnippedImage;
    }

    public void interact() {
        Debug.Log("INTERACT with: " + gameObject.name);
    }    
}
