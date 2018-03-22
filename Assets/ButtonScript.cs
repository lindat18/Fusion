using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    bool pressed;
    public Color pressedColor;
    public string playerString;

    UnityEngine.UI.ColorBlock defaultColors;

    public string getPlayerString(){
        return playerString;
    }

    public bool isPressed(){
        return pressed;
    }

    public void clicked(){
        pressed = !pressed;

        if (pressed == true)
        {
            UnityEngine.UI.ColorBlock colors = GetComponent<UnityEngine.UI.Button>().colors;
            colors.normalColor = pressedColor;
            colors.highlightedColor = pressedColor;
            colors.pressedColor = pressedColor;
            GetComponent<UnityEngine.UI.Button>().colors = colors;
        }
        else
        {
            GetComponent<UnityEngine.UI.Button>().colors = defaultColors;
        }
    }

	// Use this for initialization
	void Start () {
        defaultColors = GetComponent<UnityEngine.UI.Button>().colors;
        pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
