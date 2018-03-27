using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    public int startingHealth;

    int health = 100;

    public float maxForce;
    public float minForce;
    private float force;


    public int getHealth()
    {
        return health;
    }

    public void reset()
    {
        force = Random.value * (maxForce - minForce) + minForce;
        health = startingHealth;
        gameObject.GetComponent<Renderer>().material.color = new Color((float)health / startingHealth, 0f, 0f, 0f);
    }

    void OnCollisionEnter(Collision col)//called when collision occurs
    {
        //Debug.Log(col.collider is SphereCollider);
        if (col.gameObject.tag.Equals("Bullet"))
        {
            health -= 20;
            gameObject.GetComponent<Renderer>().material.color = new Color((float)health / startingHealth, 0f, 0f, 0f);
        }
    }



    // Use this for initialization
    void Start()
    {
        reset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followPlayer();
    }

    private void followPlayer()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;

        float magnitudeDistance = (playerPos - transform.position).magnitude;
        Vector3 newDirection = new Vector3((playerPos.x - transform.position.x) / magnitudeDistance, 0, (playerPos.z - transform.position.z) / magnitudeDistance);
        transform.forward = newDirection;
        GetComponent<Rigidbody>().AddForce(newDirection * force);
    }
}
