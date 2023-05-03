using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public bool isMoving= false;
    public Vector3 moveDirection;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving) {
            transform.position += moveDirection * Time.deltaTime * speed;
        }
    }

    public void setDirection (Vector3 direction) {
        isMoving = true;
        moveDirection = (direction - transform.position).normalized;
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player") {
            col.gameObject.GetComponent<PlayerAction>().takeDamage();
            Destroy(gameObject);
        } else if(col.tag == "PlayerInv") {
            Destroy(gameObject);
        }
    }


}
