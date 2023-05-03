using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    private Vector3 moveDirection;

    public int direction;

    private Rigidbody2D rb;

    private bool moving = false;
    private bool isDead = false;
    bool deathSwitch = false;
    private float deathTimer = 5;

    public float overallDeathTimer = 10;

    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        overallDeathTimer -= Time.deltaTime;
        if(overallDeathTimer <=0) {
            Destroy(gameObject);
        }
        if(moving) {
        transform.position += moveDirection*Time.deltaTime;
        }
        if(deathSwitch) {
            deathTimer -= Time.deltaTime;
        }
        if(deathTimer <= 0) {
            Destroy(gameObject);
        }

    }

    public void setMoving(int m) {
        moveDirection = new Vector3(0.25f*m,0,0);
        moving = true;
    }

    public void TurnAround() {
        Debug.Log("Ground Enemy Turn");
        float m = moveDirection.x;
        if(m > 0) {
            moveDirection = new Vector3(0.25f*-1,0,0);
            transform.localScale = new Vector3(-1, transform.localScale.y, 1);
        } else {
            transform.localScale = new Vector3(1, transform.localScale.y, 1);
            moveDirection = new Vector3(0.25f,0,0);
        }
    }

     public void changeDirection(Vector3 direction) {
        Destroy(rb);
        ps.Play();
        gameObject.tag = "SkullFlying";
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = new Quaternion(0,0,transform.rotation.z + 90,1);
        moveDirection = direction.normalized * 2;
        deathSwitch = true;
     }
    public void Hit() {

        GetComponent<Animator>().SetTrigger("die");
        gameObject.tag = "SkullFlying";
        isDead = true;
        rb.AddForce(Vector2.up, ForceMode2D.Impulse);
        moveDirection *= 0.5f;
    }

    public void kill() {
        Destroy(gameObject);
    }



    public void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Ground") {
            if(isDead) {
                moving = false;
                Debug.Log("this is running");
                GetComponent<Animator>().SetTrigger("die2");
            }
        }
    }




}
