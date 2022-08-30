using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Icon
{
    // information that is here will be created at the instantation of the gear.
    public Sprite icon;   // Image
    public Animator Effect;  // Adj (Removed)
    public Sprite Color;    // Type
    public Sprite Border; // Rarity

    public Icon() // Null Constructor
    {

    }
    public Icon(Sprite iconInfo,Animator efInfo, Sprite clrInfo ,Sprite bdrInfo ) // Full Constructor
    {
        icon = iconInfo;
        Effect = efInfo;
        Color = clrInfo;
        Border = bdrInfo;
    }
}