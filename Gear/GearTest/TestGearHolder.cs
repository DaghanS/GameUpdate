using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestGearHolder : MonoBehaviour
{
    public TestGear gear;
    GameObject inv;

    public void Start() // construction of testgear object. with randomised values later.
    {
        inv = GameObject.FindGameObjectWithTag("Inventory");

        // new gear creation should not be here 
    }
    public void Collector()
    {
        inv.GetComponent<TestInventory>().addInventory(gear);
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
