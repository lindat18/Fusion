using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldActivater : MonoBehaviour {
	
	int number;

	public GameObject SnowWorld;
	public GameObject GrassWorld;
	public GameObject DesertWorld;

	// Use this for initialization
	void Start () {
		number = Random.Range(0,4);
		print (number);


		if (number == 1) {
			GrassWorld.SetActive (false);
			DesertWorld.SetActive (false);
			Debug.Log ("Snow");

		} else if (number == 2) {
			SnowWorld.SetActive (false);
			DesertWorld.SetActive (false);
			Debug.Log ("Grass");

		} else {
			SnowWorld.SetActive (false);
			GrassWorld.SetActive (false);
			Debug.Log ("Desert");

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
