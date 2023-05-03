using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePopupObject : MonoBehaviour
{
    public int Score;
    public float movespeed = 1;

    public float aliveTimer = 1.5f;
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, movespeed, 0) * Time.deltaTime;
        aliveTimer -= Time.deltaTime;
        if(aliveTimer <= 0) {
            Destroy(gameObject);
        }
    }

    public void setScore(int score) {
        GetComponent<TMP_Text>().text = "" + score;
    }
}
