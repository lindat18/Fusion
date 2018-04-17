using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour {

    public enum GUIState { selectionMenu, gameMenu, endMenu } // 0, 1, 2
    public GUIState state = GUIState.selectionMenu;

    Button[][] uiButtons;
    Text[][] uiText;
    int[] opaqueness;
    
	// Use this for initialization
	void Start () {
        Button[][] tempButtons = {new Button[] { GameObject.Find("CubePlayerButton").GetComponent<Button>(), GameObject.Find("CylinderPlayerButton").GetComponent<Button>(), GameObject.Find("SpherePlayerButton").GetComponent<Button>() },
                                  new Button[] { },
            new Button[] { GameObject.Find("Restart_Button").GetComponent<Button>()}};

        uiButtons = tempButtons;

        Text[][] tempText = { new Text[] {GameObject.Find("Title").GetComponent<Text>(), GameObject.Find("Subtitle").GetComponent<Text>(), GameObject.Find("Selection_Text").GetComponent<Text>()},
                              new Text[] {GameObject.Find("Score_Text").GetComponent<Text>(), GameObject.Find("Health_Text").GetComponent<Text>(), GameObject.Find("Wave_Text").GetComponent<Text>()},
            new Text[]{GameObject.Find("End_Text").GetComponent<Text>()}};

        uiText = tempText;

        int[] tempOpaque = {1, 0, 1};

        opaqueness = tempOpaque;

        for (int j = 0; j < uiButtons.Length;j++) {
            for (int i = 0; i < uiButtons[j].Length; i++)
            {
                uiButtons[j][i].gameObject.SetActive(false);
            }

            for (int i = 0; i < uiText[j].Length; i++)
            {
                uiText[j][i].gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < uiButtons[convertStatetoNumber(GUIState.selectionMenu)].Length; i++)
        {
            uiButtons[convertStatetoNumber(GUIState.selectionMenu)][i].gameObject.SetActive(true);
        }

        for (int i = 0; i < uiText[convertStatetoNumber(GUIState.selectionMenu)].Length; i++)
        {
            uiText[convertStatetoNumber(GUIState.selectionMenu)][i].gameObject.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int convertStatetoNumber(GUIState s){
        switch(s){
            case GUIState.selectionMenu:
                return 0;
            case GUIState.gameMenu:
                return 1;
            case GUIState.endMenu:
                return 2;
        }

        return -1;
    }

    public void switchScreen(GUIState newState){
        for (int i = 0; i < uiButtons[convertStatetoNumber(state)].Length; i++){
            uiButtons[convertStatetoNumber(state)][i].gameObject.SetActive(false);
        }

        for (int i = 0; i < uiText[convertStatetoNumber(state)].Length; i++)
        {
            uiText[convertStatetoNumber(state)][i].gameObject.SetActive(false);
        }

        for (int i = 0; i < uiButtons[convertStatetoNumber(newState)].Length; i++)
        {
            uiButtons[convertStatetoNumber(newState)][i].gameObject.SetActive(true);
        }

        for (int i = 0; i < uiText[convertStatetoNumber(newState)].Length; i++)
        {
            uiText[convertStatetoNumber(newState)][i].gameObject.SetActive(true);
        }

        state = newState;

        checkColor(convertStatetoNumber(newState));
    }

    public void checkColor(int index){
        gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, opaqueness[index]);
    }

}
