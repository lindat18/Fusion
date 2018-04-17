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
        if (Random.value <= 0.5f)
        {// randomizes head/body
            body = Instantiate(player1.transform.GetChild(0).gameObject);//body always first
            head = Instantiate(player2.transform.GetChild(1).gameObject);//head always second

            body.transform.position = new Vector3(0, 0.5f, 0);
            head.transform.position = player2.transform.GetChild(1).gameObject.transform.position - player2.transform.position;
        }
        else
        {
            body = Instantiate(player2.transform.GetChild(0).gameObject);//body always first
            head = Instantiate(player1.transform.GetChild(1).gameObject);//head always second

            body.transform.position = new Vector3(0, 0.5f, 0);
            head.transform.position = player1.transform.GetChild(1).gameObject.transform.position - player1.transform.position;
        }

        initPlayer();
    }

    private void initPlayer(){
        player = GameObject.Find("Player");
        player.transform.position = new Vector3(); // starts at (0, 0, 0)

        body.transform.parent = player.transform;
        body.GetComponent<Collider>().material = (PhysicMaterial)Resources.Load("pm");
        head.transform.parent = player.transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
