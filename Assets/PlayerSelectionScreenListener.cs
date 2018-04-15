using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionScreenListener : MonoBehaviour {

    List<Transform> buttons;

    string player1;
    string player2;



    public string getPlayer1()
    {
        if (player1 != null)
            return player1;
        else
            Debug.LogError("No player1 assigned");

        return null;
    }

    public string getPlayer2()
    {
        if (player2 != null)
            return player2;
        else
            Debug.LogError("No player2 assigned");

        return null;
    }

	// Use this for initialization
	void Start () {
        initButtons();


	}

    private void initButtons(){
        buttons = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++){
            if(transform.GetChild(i).tag.Equals("PlayerButton")){
                buttons.Add(transform.GetChild(i));
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        List<Transform> pressedButtons = new List<Transform>();

        for (int i = 0; i < buttons.Count; i++){
            if(buttons[i].GetComponent<ButtonScript>().isPressed()){
                pressedButtons.Add(buttons[i]);
            }
        }

        if (pressedButtons.Count == 2) //2 players selected
        {
            player1 = pressedButtons[0].GetComponent<ButtonScript>().getPlayerString();
            player2 = pressedButtons[1].GetComponent<ButtonScript>().getPlayerString();
            startGame();
            Destroy(GameObject.Find("PlayerSelectionScreen"));
        }
	}

    void startGame(){
        GameObject.Find("World").AddComponent<GameScript>();







    }
}
