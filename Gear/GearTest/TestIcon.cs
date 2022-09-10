using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestIcon
{
    public GameObject itemIcon;     // Display Icon
    public GameObject Color;        // Rarity
    public GameObject Border;       // Type / Class // could change in a way that >> holds which subclass of gear (weapon, chest etc)
    public GameObject Menu;         // item info // name, level, descriptiontext, enchantinfo
    //TestGear info;
    //public TestIcon() // later on will have name, rarity as parameters to find right sprites.
    //{
    //    // Need a data handler object with a finder script:
    //    // so that it can find the icon information from documents.
    //    itemIcon = iconLoader();
    //    Color = colorLoader();
    //    Border = borderLoader();
    //    Menu = MenuPrepare();
    //}
    public TestIcon(string name, rarity rar, int lvl, string desc) // cant add rarity as parameter 
    {
        // Need a data handler object with a finder script:
        // so that it can find the icon information from documents.
        itemIcon = iconLoader(name);        // name
        Color = colorLoader(rar);              // rarity
        Border = borderLoader();            // type / subclass  // not implemented properly
        Menu = MenuPrepare(name,lvl,desc);               // name, level, description
    }



    // THESE FUNCTIONS WILL BE RANDOMISED // these information are going to be gathered from the gear that is stored.
    public GameObject iconLoader(string name)
    {
        // find the icon object based on name!!
        GameObject icon = Resources.Load<GameObject>("Prefab/Gear/Katana/katana_ICON");
        return icon;
    }
    public GameObject colorLoader(rarity rar)
    {
        // find correct color info from rarity data
        GameObject clr = Resources.Load<GameObject>("Prefab/Color/color_circle_TYPE_Samurai");
        return clr;
    }
    public GameObject borderLoader()
    {
        GameObject brdr = Resources.Load<GameObject>("Prefab/Border/slot_borders_RARITY_COMMON");
        return brdr;
    }
    // THESE FUNCTIONS WILL BE RANDOMISED
    public GameObject MenuPrepare(string name, int lvl, string desc)
    {
        GameObject clkMenu = Resources.Load<GameObject>("Prefab/Loadout/HoverMenu");
        // need to get information from gear
        // name
        //transform.Find(colname).gameObject;
        //< TextMeshProUGUI >
        //GameObject nametext = clkMenu.transform.Find("Total Name").gameObject;
        //nametext.GetComponent<TextMeshProUGUI>().text = "Name: " + info.name;
        // level
        //GameObject lvltext = clkMenu.transform.Find("Level").gameObject;
        //lvltext.GetComponent<TextMeshProUGUI>().text = "Level: " + info.level
        // description

        return clkMenu;
    }

    // Sprites are not matching up with the slots
    // might need a new way to display items on slot locations, maybe changing the slots sprites
    // ^^^^^ this solution is not the nicest ^^^^^^
    // might deactivate slot when an item is on the slot, will make it difficult to add inventory management by swiping.
    // propably gonna be fixed with new slot and item sprites.

    //public void displayLoader(int[] location)
    //{
    //    // Instantiate empty main
    //    GameObject main = new GameObject("Item");
    //    // Instantiate weapon prefab
    //    GameObject icon = Instantiate(itemIcon, Vector3.zero, Quaternion.identity, main.transform);
    //    // Instantiate color prefab
    //    GameObject clrchild = Instantiate(Color, Vector3.zero, Quaternion.identity, main.transform);
    //    // Instantiate border prefab
    //    GameObject bdrchild = Instantiate(Border, Vector3.zero, Quaternion.identity, main.transform);
    //    // add onClick menu
    //    GameObject hover = Instantiate(Menu, Vector3.zero, Quaternion.identity, main.transform);

    //    // changing hierarchy.
    //    icon.transform.localPosition = new Vector3(0,0,0);
    //    clrchild.transform.localPosition = new Vector3(0, 0, 0);
    //    bdrchild.transform.localPosition = new Vector3(0, 0, 0);
    //    hover.transform.localPosition = new Vector3(1, -1.2f, 0);
    //    // Creation of images DONE

    //    // Display location / parent object.
    //    string rowname = "Row" + (location[0]+1);
    //    string colname = "GearSlot" + (location[1] + 1);

    //    GameObject rowObj = GameObject.Find(rowname);
    //    GameObject colObj = rowObj.transform.Find(colname).gameObject;
    //    main.transform.SetParent(colObj.transform);
    //    // inventory management //
    //    colObj.GetComponent<InventoryManager>().slotFilling(hover);
    //    main.transform.localPosition = Vector3.zero;
    //}
}
