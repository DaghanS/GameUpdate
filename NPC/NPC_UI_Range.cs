using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_UI_Range : MonoBehaviour
{
    Vector2 playerPos;
    Vector2 npcPos;
    Vector2 DistanceVector;
    float distance;
    Vector2 FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");                               // find player object
        playerPos = new Vector2(playerObj.transform.position.x, playerObj.transform.position.y); // get its position.
        return playerPos;
    }
    Vector2 NPCPosition()
    {
        npcPos = new Vector2(this.transform.position.x, this.transform.position.y);   // get this objects position
        return npcPos;
    }
    Vector2 DirectionCalc()
    {
        playerPos = FindPlayer();               // get player objects position
        npcPos = NPCPosition();                 // get this objects position
        Vector2 MovementLine = (playerPos - npcPos);    // form a new vector2 from playerposition and enemyposition
        return MovementLine;
    }
    float PlayerDistance() // pisagor
    {
        DistanceVector = DirectionCalc();
        float vectorx_psg = (DistanceVector.x * DistanceVector.x);
        float vectory_psg = (DistanceVector.y * DistanceVector.y);
        distance = Mathf.Sqrt(vectorx_psg + vectory_psg);
        return distance;
    }
    bool RangeCheck() // 8 deneycem
    {
        return (distance <= 8);
    }
    Transform chooseText() // later on this function will help with deciding which text to display.
    {
        Transform textChild = transform.Find("TextStart");
        return textChild;
    }
    void TransparencyControl()
    {
        Transform textCanvas = transform.Find("CanvasNPC");
        float transparencyVol = (1) - ((distance-2)/6);                     // distance => 2-8 arası 6
        if (transparencyVol > 1) transparencyVol = 1;                       // limit control
        if (transparencyVol < 0) transparencyVol = 0;                       // limit control
        textCanvas.GetComponent<CanvasGroup>().alpha = transparencyVol;     // transparency turned into alpha. 0-1
    }
    private void Update()
    {
        distance = PlayerDistance();
    }
    private void FixedUpdate()
    {
        if (RangeCheck()) TransparencyControl();
    }
}
