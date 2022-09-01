using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestGearHolder : MonoBehaviour
{
    TestGear gear;
    GameObject inv;
    public TextMeshProUGUI nameText;

    public void Start() // construction of testgear object. with randomised values later.
    {
        nameText.text = gameObject.transform.root.name; // root = first parent
        gear = new TestGear(12, "Tester.");
        inv = GameObject.FindGameObjectWithTag("Inventory");
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
