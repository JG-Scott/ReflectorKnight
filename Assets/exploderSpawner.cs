using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploderSpawner : MonoBehaviour
{

    public GameObject exploder;

    public float spawnTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Update() {
        if(spawnTimer <= 0) {
            spawnTimer = Random.Range(8f,10f) - (0.05f * Time.timeSinceLevelLoad);
            if(spawnTimer <= 2) {
                spawnTimer = 2;
            }
            if(GameController.getInstance().extraEnemies()) {
                int rand = Random.Range(1,3);
                spawnExploder(rand);
            } else {
                spawnExploder(1);
            }
        } else {
            spawnTimer -= Time.deltaTime;
        }
    }
    public void spawnExploder(int rand) {
        for(int i = 0; i < rand; i++) {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(0,2.2f);
        Instantiate(exploder, new Vector2(x,y), Quaternion.identity);
        }


    }
}
