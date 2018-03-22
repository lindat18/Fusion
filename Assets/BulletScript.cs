using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    float spawnTime;

    public void startBullet(){
        spawnTime = Time.time;
    }

    public float getSpawnTime(){
        return spawnTime;
    }
}
