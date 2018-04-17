using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clicked(){
        GameObject.Find("GUI").GetComponent<GUIScript>().switchScreen(GUIScript.GUIState.selectionMenu);
    }
}
