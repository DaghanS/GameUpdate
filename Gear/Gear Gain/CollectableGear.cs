using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableGear : MonoBehaviour
{
    public TestGear gear;
    GameObject inv;

    public void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory");
    }
    public void Collector()
    {
        inv.GetComponent<InventoryManager>().addInventory(gear);
        this.GetComponent<Animator>().Play("Collected");

    }
    public void GearSetter(TestGear inp)
    {
        gear = inp;
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.transform.CompareTag("Player"))
        {
            Collector();
        }
    }
}
