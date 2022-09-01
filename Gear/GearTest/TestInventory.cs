using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq; // array comparison

public class TestInventory : MonoBehaviour
{
    public TestGear[,] inventory = new TestGear[5,5];
    public static TestInventory instance = null;
    public int[] length;
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
        Debug.Log("Scenes: " + currentName + ", " + next.name);// names are a little confusing on the code, next is currentnewscene

        // original code
        if (next.name == "Loadouts") 
        {
            length = firstEmpty();
            bool breaker = false;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    int[] currentloc = { row, col };
                    if (currentloc == length)
                    {
                        breaker = true;
                        break;
                    }
                    else
                    {
                        TestDisplay(inventory[row, col].icon);
                    }

                }
                if (breaker == true) break;
            }
            // displaying of all objects.
        }
    }
    public void TestDisplay(Object icon)
    {
        GameObject obj = Instantiate(icon) as GameObject;
        obj.SetActive(true);
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
