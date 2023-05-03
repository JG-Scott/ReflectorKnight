using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderEnemy : MonoBehaviour
{

     public GameObject ps;

     private Animator anim;
     public BoxCollider2D hitBox;

     public AudioSource laser;

    public AudioSource blip;

    private bool canDie = true;

    public float upgradeTimer = 15;

    public GameObject deadSound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed += GameController.getInstance().getAnimSpeedInc();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startheadTurn() {
        anim.SetTrigger("headTurn");
    }

    public void startVomitSpit() {
        anim.SetTrigger("vomit");
        hitBox.enabled = true;
        canDie = false;
    }


    public void die() {
        Instantiate(ps, transform.position, Quaternion.identity);
        Instantiate(deadSound, transform.position, Quaternion.identity);
        hitBox.enabled = false;
        Destroy(gameObject);
    }


    public void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("enter");
        if(col.tag == "SkullFlying" && canDie) {
            Instantiate(deadSound, transform.position, Quaternion.identity);
            GameController.getInstance().scorePoints(150, transform.position);
            Instantiate(ps, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
        } else if (col.tag == "Player") {
            col.gameObject.GetComponent<PlayerAction>().takeDamage();
        }
    }


    public void playLaser() {
        laser.Play();
    }

    public void playEnterance() {
        GetComponent<AudioSource>().Play();
    }

    public void playBlip() {
        blip.Play();
    }
}
