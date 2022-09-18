using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq; // array comparison

public class TestInventory : MonoBehaviour
{
    // Inventory needs a slider menu or page system that will enable more items to be held

    // also an inventory organizing system. 
    // ^^^^ propably the event system ^^^^

    public TestGear[,] inventory = new TestGear[5,12];
    public static TestInventory instance = null;
    public int[] length;
    public Loadout activeldt;
    public void addInventory(TestGear item)
    {
        Debug.Log("WORKS");
        length = firstEmpty();
        inventory[length[0], length[1]] = item;
        Debug.Log("Addition_DONE.");
    }
    public int[] firstEmpty()
    {
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                if (inventory[row, col] == null)
                {
                    int[] loc = { row, col };
                    return loc;
                }
            }
        }
        return null; // error
    }
    private void Awake()
    {
        // load inventory and active loadout data.
        SceneManager.activeSceneChanged += ChangedActiveScene;

    }
    private void ChangedActiveScene(Scene current, Scene next)
    {
        if (instance == null) // Original Check
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) // Duplicate Check
        {
            SceneManager.activeSceneChanged -= ChangedActiveScene; // UNSUB
            Destroy(this.gameObject); // DESTROY
            return;
        }
        // this part was checking for duplicate inventory objects.


        // test
        string currentName = current.name;
        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }
        Debug.Log("Scenes: " + currentName + ", " + next.name);

        // original code
        // displaying of all objects.
        if (next.name == "Loadouts") // names are a little confusing on the code, next is currentnewscene
        {
            AllDisplay();
        }
    }
    public void AllDisplay()
    {
        length = firstEmpty();
        bool breaker = false;
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                int[] currentloc = { row, col };
                if (currentloc.SequenceEqual(length))
                {
                    breaker = true;
                    break;
                }
                else
                {
                    // Instantiation.
                    TestGear data = inventory[row, col];
                    displayLoader(currentloc, data);
                }
            }
            if (breaker == true) break;
        }
    }
    // Sprites are not matching up with the slots
    // might need a new way to display items on slot locations, maybe changing the slots sprites
    // ^^^^^ this solution is not the nicest ^^^^^^
    // might deactivate slot when an item is on the slot, will make it difficult to add inventory management by swiping.
    // propably gonna be fixed with new slot and item sprites.

    // for now i can just make regular slots a little smaller to hide this.
    public void displayLoader(int[] location, TestGear info)
    {
        // Instantiate empty main
        GameObject main = new GameObject("Item");
        main.AddComponent<TestGearHolder>();
        main.GetComponent<TestGearHolder>().gear = info;
        // Instantiate weapon prefab
        GameObject icon = Instantiate(info.icon.itemIcon, Vector3.zero, Quaternion.identity, main.transform);
        // Instantiate color prefab
        GameObject clrchild = Instantiate(info.icon.Color, Vector3.zero, Quaternion.identity, main.transform);
        // Instantiate border prefab
        GameObject bdrchild = Instantiate(info.icon.Border, Vector3.zero, Quaternion.identity, main.transform);
        // add onClick menu
        GameObject hover = Instantiate(info.icon.Menu, Vector3.zero, Quaternion.identity, main.transform);

        // Adding components.
        // add canvas group
        // add a dragger
        main.AddComponent<CanvasGroup>();
        main.AddComponent<DragDrop>();


        // changing hierarchy.
        icon.transform.localPosition = new Vector3(0, 0, 0);
        clrchild.transform.localPosition = new Vector3(0, 0, 0);
        bdrchild.transform.localPosition = new Vector3(0, 0, 0);
        hover.transform.localPosition = new Vector3(1, -1.2f, 0);
        // Creation of images DONE

        // Display location / parent object.
        string rowname = "Row" + (location[0] + 1);
        string colname = "GearSlot" + (location[1] + 1);

        GameObject rowObj = GameObject.Find(rowname);
        GameObject colObj = rowObj.transform.Find(colname).gameObject;
        main.transform.SetParent(colObj.transform);
        // inventory management //
        colObj.GetComponent<SlotManage>().slotFilling(hover);
        main.transform.localPosition = Vector3.zero;
    }

    //public int[] FirstEmptyCoord() // unoptimized
    //{
    //    for (int pagei = 0; pagei < pageInfo; pagei++)
    //    {
    //        for (int rowi = 0; rowi < rowAmount; rowi++)
    //        {
    //            for (int coli = 0; coli < colAmount; coli++)
    //            {
    //                if (InventoryArray[pagei, rowi, coli] == null)
    //                {
    //                    int[] cords = { pagei, rowi, coli };
    //                    return cords;
    //                }
    //            }
    //        }
    //    }
    //    // error: inventory is full.
    //    return null;
    //}
}
