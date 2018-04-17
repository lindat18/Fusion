using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    // Use this for initialization
    public GameObject ball;
    public int pooledAmount = 10;

    List<GameObject> balls;

    public Rigidbody rb;
    public float fireSpeed = 50f;
    public float bulletCooldown = 0.2f;//seconds
    private float lastBullet = 0;

    void Start()
    {
        ball = GameObject.Find("bulletTest");
        balls = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(ball);
            obj.SetActive(false);
            balls.Add(obj);
        }

        this.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }

        for (int i = 0; i < balls.Count; i++)
        {
            if (Time.time - balls[i].GetComponent<BulletScript>().getSpawnTime() > 2) // bullet lasts 2 seconds
            {
                balls[i].GetComponent<Rigidbody>().velocity = new Vector3();//set bullet velocity to zero
                balls[i].SetActive(false);
            }
        }
    }
    void Fire()
    {
        if (Time.time - lastBullet > bulletCooldown)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                if (!balls[i].activeInHierarchy)
                {
                    balls[i].GetComponent<BulletScript>().startBullet();
                    balls[i].transform.position = transform.position + new Vector3(0, 1.25f, 0) + (transform.forward * 1f);
                    balls[i].transform.rotation = transform.rotation;
                    balls[i].SetActive(true);
                    Rigidbody tempRb = balls[i].GetComponent<Rigidbody>();
                    tempRb.AddForce((transform.forward * fireSpeed), ForceMode.Impulse);
                    lastBullet = Time.time;
                    break;
                }
            }
        }
    }
}

