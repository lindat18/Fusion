using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

    PlayerCombinationScript playerGenerator;
    GameObject player;

	// Use this for initialization
	void Start () {
        playerGenerator = gameObject.AddComponent<PlayerCombinationScript>();

        GameObject.Find("Player").GetComponent<Shoot>().enabled = true;

        PlayerSelectionScreenListener listener = GameObject.Find("PlayerSelectionScreen").GetComponent<PlayerSelectionScreenListener>();
        playerGenerator.createCombination(GameObject.Find(listener.getPlayer1()).gameObject, GameObject.Find(listener.getPlayer2()).gameObject);
        player = playerGenerator.getPlayer();
        player.AddComponent<PlayerController>();

        GetComponent<ZombieGenerator>().GenerateNewZombies(100000);
	}

    public GameObject getPlayer(){
        return player;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
