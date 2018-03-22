using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoMessageScript : MonoBehaviour {

    public string characterMessage;
    public string infoMessage;

    public void onHover(){
        if (GetComponent<UnityEngine.UI.Text>().text != "Selected")
            GetComponent<UnityEngine.UI.Text>().text = infoMessage;
    }

    public void onHoverExit()
    {
        if (GetComponent<UnityEngine.UI.Text>().text != "Selected")
            GetComponent<UnityEngine.UI.Text>().text = characterMessage;
    }

    public void clicked()
    {
        if (GetComponent<UnityEngine.UI.Text>().text != "Selected")
            GetComponent<UnityEngine.UI.Text>().text = "Selected";
        else
            GetComponent<UnityEngine.UI.Text>().text = infoMessage;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
