using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

    public int startingHealth;
    public float speed = 1;
    int health = 100;

    public int getHealth(){
        return health;
    }

    public void resetHealth()
    {
        health = startingHealth;
        gameObject.GetComponent<Renderer>().material.color = new Color((float)health / startingHealth, 0f, 0f, 0f);
    }

    void OnCollisionEnter(Collision col)//called when collision occurs
    {
        //Debug.Log(col.collider is SphereCollider);
        if (col.collider is SphereCollider)
        {
            health -= 20;
            gameObject.GetComponent<Renderer>().material.color = new Color((float)health/startingHealth, 0f, 0f, 0f);
        }
    }

	// Use this for initialization
	void Start () {
        resetHealth();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        followPlayer();
	}

    private void followPlayer(){
        Vector3 playerPos = GameObject.Find("Player").transform.position;

        float magnitudeDistance = (playerPos - transform.position).magnitude;
        float newX = transform.position.x + (playerPos.x - transform.position.x)/magnitudeDistance * speed * Time.deltaTime;
        float newZ = transform.position.z + (playerPos.z - transform.position.z) / magnitudeDistance * speed * Time.deltaTime;;

        transform.position = new Vector3(newX, transform.localScale.y, newZ);
    }
}
