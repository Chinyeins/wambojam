using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snippet : InventoryItem
{
    public SnippetType snippetType;

    public Image SnippedImage;



    public Image getImage() {
        return this.SnippedImage;
    }    
}
