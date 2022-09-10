using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestGearHolder : MonoBehaviour
{
    public TestGear gear;
    GameObject inv;
    public TextMeshProUGUI nameText;

    public void Start() // construction of testgear object. with randomised values later.
    {
        nameText.text = gameObject.transform.root.name; // root = first parent
        //gear = new TestGear(); // new gear creation should not be here  !!!!!!!!!!!!!!!!!!!!!!!!! gear should be constructed from npc OR enemy object.
        inv = GameObject.FindGameObjectWithTag("Inventory");

        // new gear creation should not be here 
    }
    public void Collector()
    {
        nameText.gameObject.SetActive(true);
        inv.GetComponent<TestInventory>().addInventory(gear);
        this.GetComponent<Animator>().Play("Collected");

    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.transform.CompareTag("Player"))
        {
            Collector();
        }
    }
}
