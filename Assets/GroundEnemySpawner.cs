using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemySpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public List<GameObject> enemy;

    public float spawnTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if(spawnTimer <= 0) {
           spawnTimer = Random.Range(1f,3f) - (0.01f * Time.timeSinceLevelLoad);
            if(spawnTimer <= 1) {
                spawnTimer = 1f;
            }
            float side = Random.Range(0f,100f);
            if(side < 50) {
                spawnLeft(0);
            } else {
                spawnRight(0);
            }
        } else {
            spawnTimer -= Time.deltaTime;
        }
    }


    public void spawnLeft(int enemyID) {
        GameObject e = Instantiate(enemy[enemyID], spawnPoints[0].transform.position, Quaternion.identity);
        e.transform.localScale = new Vector3(e.transform.localScale.x*-1, e.transform.localScale.y, 1);
        e.GetComponent<GroundEnemy>().setMoving(1);
    }

    public void spawnRight(int enemyID) {
          GameObject e = Instantiate(enemy[enemyID], spawnPoints[1].transform.position, Quaternion.identity);
          e.GetComponent<GroundEnemy>().setMoving(-1);
    }

}
