using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour {

    public enum GUIState { selectionMenu, gameMenu, endMenu }
    public GUIState state;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
    void OnGUI()
    {
        switch (state)
        {
            case GUIState.selectionMenu: DrawSelectionMenu(); break;
            case GUIState.gameMenu: DrawGameMenu(); break;
            case GUIState.endMenu: DrawEndMenu(); break;
        }
    }

    void DrawSelectionMenu()
    {
        
    }

    void DrawGameMenu()
    {
        
    }

    void DrawEndMenu()
    {
        
    }
}
