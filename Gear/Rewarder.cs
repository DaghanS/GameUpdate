using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rewarder : MonoBehaviour
{
    public GameObject chosen;
    public GameObject[] enemies;
    public bool rewarded;
    public TextMeshProUGUI nameText;
    void Start()
    {
        rewarded = false;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        chooseEnemy();
    }
    public void chooseEnemy()
    {
        int chosenindex = Random.Range(0, enemies.Length);
        chosen = enemies[chosenindex];
    }
    public void Update()
    {
        if ( !rewarded && chosen != null && !chosen.GetComponent<TestAI>().alive)
        {
            Reward();
            rewarded = true;
            nameText.text = "Thanks for the Flesh...";
        }
    }
    public void Reward()
    {
        GameObject spawn = Resources.Load<GameObject>("Prefab/Collectable");
        GameObject spawncopy = Instantiate(spawn);
        TestGear iteminf = new TestGear();
        spawncopy.GetComponent<TestGearHolder>().GearSetter(iteminf);
    }
}
