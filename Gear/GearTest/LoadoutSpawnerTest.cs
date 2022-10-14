using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutSpawnerTest : MonoBehaviour
{
    GameObject Inventory;
    public void Awake()
    {
        Inventory = GameObject.FindGameObjectWithTag("Inventory");
    }
    public void Reward()
    {
        TestGear iteminf = new TestGear();
        Inventory.GetComponent<InventoryManager>().addInventory(iteminf);
    }
}
