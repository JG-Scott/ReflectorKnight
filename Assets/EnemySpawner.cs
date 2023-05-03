using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{




    public List<GameObject> spawnPoints;

    public GameObject enemy;
    public float spawnTimer = 1;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
          if(spawnTimer <= 0) {
            spawnTimer = Random.Range(8f,10f) - (0.05f * Time.timeSinceLevelLoad);
            if(spawnTimer <= 2) {
                spawnTimer = 2f;
            }
            if(GameController.getInstance().extraEnemies()) {
                int rand = Random.Range(1,3);
                spawnFireBall(rand);
            } else {
                spawnFireBall(1);
            }
        } else {
            spawnTimer -= Time.deltaTime;
        }
        
    }


    public void spawnFireBall(int rand) {
        for(int i = 0; i < rand; i ++) {
            int rSpawn = Random.Range(0,6);
            Instantiate(enemy, spawnPoints[rSpawn].transform.position, Quaternion.identity);
        }
    }
}
