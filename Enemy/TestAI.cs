using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestAI : MonoBehaviour
{
    // this algorithm will be for singleplayer
    Vector2 netspeed;
    Vector2 direction;
    public Rigidbody2D enemyrb;
    public float enemySpeed;
    public bool alive;

    public bool following;

    Vector2 FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");                               // find player object
        Vector2 playerPos = new Vector2(playerObj.transform.position.x, playerObj.transform.position.y); // get its position.
        return playerPos;
    }
    Vector2 EnemyPosition()
    {
        Vector2 enemyPos = new Vector2(this.transform.position.x, this.transform.position.y);   // get this objects position
        return enemyPos;
    }
    Vector2 DirectionCalc()
    {
        Vector2 playerPos = FindPlayer();              // get player objects position
        Vector2 enemyPos = EnemyPosition();            // get this objects position
        Vector2 MovementLine = (playerPos - enemyPos); // form a new vector2 from playerposition and enemyposition
        return MovementLine; 
    }
    Vector2 SpeedCalc(Vector2 direction)
    {
        float distance = PlayerDistance();
        Vector2 netspeed = new Vector2(direction.x / distance, direction.y / distance);
        return netspeed;
    } // setting speed to one certain value using sin and cos.
    float PlayerDistance() // finding distance to player
    {
        Vector2 DistanceVector = DirectionCalc();
        float vectorx_psg = (DistanceVector.x * DistanceVector.x);
        float vectory_psg = (DistanceVector.y * DistanceVector.y);
        float distance = Mathf.Sqrt(vectorx_psg + vectory_psg);
        return distance;
    }
    void Chase(Vector2 direction)
    {
        enemyrb.velocity = direction*enemySpeed;          // add velocity in that line
    }
    private void Start()
    {
        enemyrb = GetComponent<Rigidbody2D>();            // get rb of enemy object
        // used to stop AI while death animation is active.
        alive = true;
    }
    private void Update()
    {
        direction = DirectionCalc();
        netspeed = SpeedCalc(direction);
    }
    private void FixedUpdate()
    {
        if(alive && following)Chase(netspeed);
    }
    // Görüş açısı lazım, objeden belli bir uzaklığa kadar giden ışınlar atıp temasına göre kontrol yapılabilir. Görüş açısında olan objelerden biri playersa chase çalışcak.
    // direction affects speed. separate direction and speed.
}
