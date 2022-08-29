using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRange : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.GetComponentInParent<TestAI>().following = false;
        GetComponentInParent<TestAI>().enemyrb.velocity = Vector2.zero;
    }
}
