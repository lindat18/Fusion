using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

    PlayerCombinationScript playerGenerator;
    GameObject player;

    ZombieGenerator generator;

    private int wave = 1;
    int numStartZombies = 2;

	// Use this for initialization
	void Start () {
        playerGenerator = gameObject.AddComponent<PlayerCombinationScript>();

        GameObject.Find("Player").GetComponent<Shoot>().enabled = true;

        PlayerSelectionScreenListener listener = GameObject.Find("PlayerSelectionScreen").GetComponent<PlayerSelectionScreenListener>();
        playerGenerator.createCombination(GameObject.Find(listener.getPlayer1()).gameObject, GameObject.Find(listener.getPlayer2()).gameObject);
        player = playerGenerator.getPlayer();
        player.AddComponent<PlayerController>();
        
        generator = GetComponent<ZombieGenerator>();
        generator.GenerateNewZombies(numStartZombies);
        updateWaveText();
	}

    public GameObject getPlayer(){
        return player;
    }

    private void updateWaveText(){
        var healthText = GameObject.Find("Wave_Text").GetComponent<UnityEngine.UI.Text>();
        healthText.color = new Color(1, 0, 0);
        healthText.text = "Wave: " + wave + "\n " + generator.zombiesRemaining() + " zombies left";
    }
	
	// Update is called once per frame
	void Update () {
        updateWaveText();
        if (generator.zombiesRemaining() == 0)
        {
            wave++;
            if (wave % 4 == 0)
                generator.maxAliveAtOnce++;

            Debug.Log(generator.maxAliveAtOnce);

            generator.GenerateNewZombies(numStartZombies + (wave - 1) * 5);
            updateWaveText();
            Debug.Log("Wave: " + wave);
        }
	}
}
