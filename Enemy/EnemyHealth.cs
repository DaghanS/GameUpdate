using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float healthcontainer;
    public Image HealthBar;
    void Start()
    {
        health = 100;
    }
    void Update()
    {
        // Enemy Health Display //
        healthcontainer = health / 100;
        HealthBar.fillAmount = healthcontainer;
        // Enemy Health Display //


        if (health <= 0) // deathcheck
        {
            onDeath();
        }
    }
    void onDeath()
    {
        this.GetComponent<TestAI>().alive = false; // stop Chase algorithm
        this.GetComponent<Animator>().Play("DeathProcess"); // slowly decrease transparency,
        // when its 0, destroy object.
    }
}