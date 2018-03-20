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
    private float fireSpeed = 10f;
    void Start()
    {
        balls = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(ball);
            obj.SetActive(false);
            balls.Add(obj);
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    void Fire()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            if (!balls[i].activeInHierarchy)
            {
                balls[i].transform.position = transform.position + (transform.forward * 1f);
                balls[i].transform.rotation = transform.rotation;
                balls[i].SetActive(true);
                Rigidbody tempRb = balls[i].GetComponent<Rigidbody>();
                tempRb.AddForce((transform.forward * fireSpeed), ForceMode.Impulse);
                break;
            }
        }

    }

}

