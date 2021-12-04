using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemType
{
    public enum InventoryTypeAction
    {
        ITA_STORY,
        ITA_RESETLEVEL,
        ITA_NEWTARGET
    }
    public bool isUnique = false;
    public InventoryTypeAction InventoryTypeAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
