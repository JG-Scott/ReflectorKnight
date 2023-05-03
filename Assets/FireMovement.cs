using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    public GameObject ps;
    public float speed = 0.35f;

    public float shotCD = 3f;

    public GameObject fire;
    public GameObject deathSound;
    void Start()
    {
        moveDirection = new Vector3(0,-1,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 0.3f) {
            transform.position += moveDirection*Time.deltaTime *(speed+(GameController.getInstance().getAnimSpeedInc()/10));
        } else {
            if(shotCD <= 0) {
                shootFire();
                shotCD = 3;
            } else {
                shotCD-=Time.deltaTime;
            }
        }   

        // if(upgradeTimer <=0) {
        //     anim.speed += 0.15f;
        //     upgradeTimer += 15;
        // }

    }

    public void shootFire() {
        GameObject e = Instantiate(fire, transform.position, Quaternion.identity);
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        e.GetComponent<FireBall>().setDirection(playerPos);
    }

    public void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("enter");
        if(col.tag == "SkullFlying") {
            Instantiate(deathSound, transform.position, Quaternion.identity);
            GameController.getInstance().scorePoints(100, transform.position);
            Instantiate(ps, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}
