using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.GetComponentInParent<TestAI>().following = true;
    }
}
