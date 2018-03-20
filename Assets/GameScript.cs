using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

    PlayerCombinationScript playerGenerator;

	// Use this for initialization
	void Start () {
        playerGenerator = new PlayerCombinationScript();

        playerGenerator.createCombination(GameObject.Find("CubePlayer"), GameObject.Find("SpherePlayer"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
