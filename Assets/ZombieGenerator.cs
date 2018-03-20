﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour {

    public GameObject zombie;
    public int maxAliveAtOnce = 50;
    List<GameObject> zombiesList;

    int numGeneratedTotal = 0; //number of zombies generated

    int numToGenerate;//# of zombies to generate this round
    int numGeneratedRecent;//num generated since last call to "GenerateNewZombies"


    // Use this for initialization
    void Start(){
        
    }

    private void GenerateNewZombies(int amount) //resets list and generates a new group
    {
        numGeneratedRecent = 0;
        this.numToGenerate = amount;
        zombiesList = new List<GameObject>();
        for (int i = 0; i < maxAliveAtOnce && i < amount; i++)
        {
            spawnZombie();
        }
    }

    private void spawnZombie(){ // just initialized; not active just yet
        GameObject obj = (GameObject)Instantiate(zombie);
        obj.SetActive(false);
        obj.transform.position = new Vector3(0, obj.transform.localScale.y, 0); //spawns at center of world
        zombiesList.Add(zombie);
    }

    // Update is called once per frame
    void FizedUpdate()
    {
        HandleZombiePooling();
    }

    private void HandleZombiePooling()
    {
        for (int i = 0; i < maxAliveAtOnce && i < numToGenerate && numGeneratedRecent < numToGenerate; i++)
        {
            if (!zombiesList[i].activeInHierarchy)
            {
                numGeneratedRecent++;
                numGeneratedTotal++;
                zombiesList[i].transform.position = new Vector3(0, zombiesList[i].transform.localScale.y, 0);
                zombiesList[i].GetComponent<ZombieController>().resetHealth();
                zombiesList[i].SetActive(true);
                break;
            }
        }

        for (int i = 0; i < maxAliveAtOnce && i < numToGenerate; i++)
        {
            if (zombiesList[i].GetComponent<ZombieController>().getHealth() <= 0) // remove platform after player has gone 50 units past it
            {
                zombiesList[i].SetActive(false);
            }
        }
    }

    private void RemovePlatforms()
    {
        foreach (GameObject obj in zombiesList)
        {
            Destroy(obj);
        }
    }

    public void Reset()
    {
        numGeneratedTotal = 0;
        numGeneratedRecent = 0;
        numToGenerate = 0;
        zombiesList = null;
    }
}