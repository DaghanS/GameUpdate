using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.z = -10f;
        transform.position = pos;
    }
}
