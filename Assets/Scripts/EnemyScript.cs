using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int directionX;
    public int directionY;
    public new Transform transform;
    

    void Start()
    {
        directionX = Random.Range(0, 2);
        directionY = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "LeftWall")
        {
            directionX = 0;
        }
        if (collision.gameObject.tag == "RightWall")
        {
            directionX = 1;
        }

        if (collision.gameObject.tag == "UpperWall")
        {
            directionY = 1;
        }
        if (collision.gameObject.tag == "LowerWall")
        {
            directionY = 0;
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            if (transform.position.x <= collision.gameObject.transform.position.x || transform.position.x >= collision.gameObject.transform.position.x)
            {
                directionX ^= 1;
            }
            if (transform.position.y <= collision.gameObject.transform.position.y || transform.position.y >= collision.gameObject.transform.position.y)
            {
                directionY ^= 1;
            }

            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerScript>().loseHealth();
            }
        }
    }
}
