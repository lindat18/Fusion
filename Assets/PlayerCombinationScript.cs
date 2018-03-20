using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombinationScript : MonoBehaviour {

    GameObject player;
    GameObject head;
    GameObject body;

    public GameObject getPlayer(){
        return player;
    }

	// Use this for initialization
	void Start () {
        
	}

    public void createCombination(GameObject player1, GameObject player2){
        //pass in entire player object not just head/body

        if(Random.Range(0, 1) <= 0.5){// randomizes head/body
            body = player1.transform.GetChild(0).gameObject;//body always first
            head = player2.transform.GetChild(1).gameObject;//head always second

            body.transform.position -= player1.transform.position;
            head.transform.position -= player2.transform.position;
        }else{
            body = player2.transform.GetChild(0).gameObject;//body always first
            head = player1.transform.GetChild(1).gameObject;//head always second

            body.transform.position -= player2.transform.position;
            head.transform.position -= player1.transform.position;
        }

        initPlayer();
    }

    private void initPlayer(){
        player = new GameObject();
        player.transform.position = new Vector3(); // starts at (0, 0, 0)

        body.transform.parent = player.transform;
        head.transform.parent = player.transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
