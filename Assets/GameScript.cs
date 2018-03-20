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
        setupPlayer();

        GetComponent<ZombieGenerator>().GenerateNewZombies(100000);
	}

    private void setupPlayer(){
        player.GetComponent<PlayerController>().enabled = true;
    }

    public GameObject getPlayer(){
        return player;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
