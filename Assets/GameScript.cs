using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

    PlayerCombinationScript playerGenerator;
    GameObject player;

	// Use this for initialization
	void Start () {
        playerGenerator = new PlayerCombinationScript();

        playerGenerator.createCombination(GameObject.Find("CubePlayer"), GameObject.Find("SpherePlayer"));
        player = playerGenerator.getPlayer();

        GetComponent<ZombieGenerator>().GenerateNewZombies(10);
	}

    public GameObject getPlayer(){
        return player;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
