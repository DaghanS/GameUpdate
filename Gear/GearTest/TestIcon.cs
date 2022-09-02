using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIcon : MonoBehaviour
{
    Sprite itemIcon;    // Object Shape
    Sprite Color;       // Rarity
    Sprite Border;      // Type / Class
    public TestIcon() // later on will have name, rarity as parameters to find right sprites.
    {
        // Need a data handler object with a finder script:
        // so that it can find the icon information from documents.
        itemIcon = iconLoader();
        Color = colorLoader();
        Border = borderLoader();

    }


    // THESE FUNCTIONS WILL BE RANDOMISED
    public Sprite iconLoader()
    {
        Sprite icon = Resources.Load<Sprite>("Prefab/Gear/katana_ICON");
        return icon;
    }
    public Sprite colorLoader()
    {
        Sprite clr = Resources.Load<Sprite>("Prefab/slotColor/color_circle_TYPE_Samurai");
        return clr;
    }
    public Sprite borderLoader()
    {
        Sprite brdr = Resources.Load<Sprite>("Prefab/slotBorder/slot_borders_RARITY_COMMON");
        return brdr;
    }
    // This display function has one problem that might slow me down a lot during the whole project:
    // the problem is that I can not predetermine the size and the rotation of the objects before creating them.
    // I have to be very precise with my art and / or correct things in code.
    // creating prefabs of sprites as game objects might be the better way of keeping things organized and flexible. !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public void displayLoader() // will get location or parent object as location parameter.
    {
        // Instantiate empty
        GameObject main = new GameObject("item");
        // add main icon sprite.
        main.AddComponent<SpriteRenderer>();
        main.GetComponent<SpriteRenderer>().sprite = itemIcon;
        main.GetComponent<SpriteRenderer>().sortingOrder = 1;
        // Instantiate empty
        GameObject clrchild = new GameObject("color");
        // add color.
        clrchild.AddComponent<SpriteRenderer>();
        clrchild.GetComponent<SpriteRenderer>().sprite = Color;
        clrchild.GetComponent<SpriteRenderer>().sortingOrder = 0;
        // Instantiate empty
        GameObject bdrchild = new GameObject("border");
        // add border.
        bdrchild.AddComponent<SpriteRenderer>();
        bdrchild.GetComponent<SpriteRenderer>().sprite = Border;
        bdrchild.GetComponent<SpriteRenderer>().sortingOrder = 1;
        // changing hierarchy.
        clrchild.transform.SetParent(main.transform);
        bdrchild.transform.SetParent(main.transform);
        main.transform.position = new Vector3(0,0,0);
        clrchild.transform.position = new Vector3(0, 0, 0);
        bdrchild.transform.position = new Vector3(0, 0, 0);
    }
}
