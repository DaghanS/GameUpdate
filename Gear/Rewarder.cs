using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewarder : MonoBehaviour
{
    public GameObject chosen;
    public GameObject[] enemies;
    public bool rewarded;
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
        if (!chosen.GetComponent<TestAI>().alive && !rewarded)
        {
            Reward();
            rewarded = true;
        }
    }
    public void Reward()
    {
        GameObject spawn = Resources.Load<GameObject>("Prefab/Collectable");
        Instantiate(spawn);
        spawn.GetComponent<TestGearHolder>().gear = new TestGear();
    }
}
