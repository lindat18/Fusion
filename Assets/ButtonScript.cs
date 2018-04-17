using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    bool pressed;
    public Color pressedColor;
    public string playerString;

    ColorBlock defaultColors;

    public string getPlayerString(){
        return playerString;
    }

    public bool isPressed(){
        return pressed;
    }

    public void setPressed(bool b){
        pressed = b;

        if(b == false){
            GetComponent<Button>().colors = defaultColors;
        }
    }

    public void clicked(){
        if (gameObject.activeInHierarchy)
        {
            pressed = !pressed;

            if (pressed == true)
            {
                ColorBlock colors = GetComponent<Button>().colors;
                colors.normalColor = pressedColor;
                colors.highlightedColor = pressedColor;
                colors.pressedColor = pressedColor;
                GetComponent<Button>().colors = colors;
            }
            else
            {
                GetComponent<Button>().colors = defaultColors;
            }
        }
    }

	// Use this for initialization
	void Start () {
        defaultColors = GetComponent<Button>().colors;
        pressed = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
