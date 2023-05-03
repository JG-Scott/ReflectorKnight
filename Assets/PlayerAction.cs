using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float horizontalMovementFloat;

    public GameObject arrow;

    public GameObject shield;

    public int dashDirection = 0;

    public float dashTrailOff = 1f;

    public int health = 3;

    public Vector3 dashVector = Vector3.zero;

    public bool isDashing = false;

    public float arrowSensitivity = 10;

    private bool invulnerable = false;

    private float invulnerableTimer = 3f;

public float spriteBlinkingTimer = 0.0f;
 public float spriteBlinkingMiniDuration = 0.1f;
 public float spriteBlinkingTotalTimer = 0.0f;
 public float spriteBlinkingTotalDuration = 3.0f;
 public bool startBlinking = false;

    


    public Animator anim;

    public BoxCollider2D rbc;

    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing && dashTrailOff > 0) {
            transform.position += dashVector * Time.deltaTime * dashTrailOff;
            dashTrailOff -=0.1f;
            
        } else {
            isDashing = false;
            dashTrailOff = 1;
            int layer = LayerMask.NameToLayer("PlayerNoHit");
            gameObject.layer = layer;
            rbc.enabled = false;
        }

        if(invulnerable) {
            invulnerableTimer -= Time.deltaTime;
            gameObject.tag = "PlayerInv";
        } else {
            invulnerableTimer = 3f;
        }

        if(invulnerableTimer <= 0) {
            invulnerable = false;
            gameObject.tag = "Player";
        }

        if(startBlinking == true)
         { 
            SpriteBlinkingEffect();
         }


         if(!GameController.getInstance().getControllerType()) {
            MoveArrow("mouse");
         }
    }

    private void SpriteBlinkingEffect()
      {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if(spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
              startBlinking = false;
             spriteBlinkingTotalTimer = 0.0f;
             this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   // according to 
                      //your sprite
             return;
          }
     
     spriteBlinkingTimer += Time.deltaTime;
     if(spriteBlinkingTimer >= spriteBlinkingMiniDuration)
     {
         spriteBlinkingTimer = 0.0f;
         if (this.gameObject.GetComponent<SpriteRenderer> ().enabled == true) {
             this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;  //make changes
         } else {
             this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   //make changes
         }
     }
 }

    public void Move(Vector3 vec, int dashD) {
        dashDirection = dashD;
        if(dashD == 2) {
            GameObject.Find("Player").transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        } else {
             GameObject.Find("Player").transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if(!isDashing) {
            anim.SetBool("IsMoving", true);
            transform.position += vec;
            
        } 
    }

    public void takeDamage() {
        GetComponent<PlayerSoundHandler>().playHurt();
        startBlinking = true;
        health -= 1;
        if(health <= 0) {
            GameController.getInstance().resetGame();
        } else {
            GameController.getInstance().updateHealth(health);
            invulnerable = true;
        }
    }


    public void MoveArrow(string direction) {

        if(GameController.getInstance().getControllerType()) {
        float currentDirection = arrow.transform.eulerAngles.z;
        if(currentDirection > 71) {
            currentDirection = currentDirection - 360;
        }
        //Debug.Log(currentDirection);
        if(direction == "right") {
            if(currentDirection > -70) {
                arrow.transform.eulerAngles += new Vector3(0,0,-arrowSensitivity*Time.deltaTime);
            }
        } else {
           //Debug.Log(currentDirection);
            if(currentDirection< 70) {
                arrow.transform.eulerAngles += new Vector3(0,0,arrowSensitivity*Time.deltaTime); 
            }
        }
        } else {
            Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arrow.transform.position;
            dif.Normalize();
            float rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.Euler(0,0,rotZ-90); 

            
        }

    }


    public void dash() {
        anim.SetTrigger("SwordSwingTrigger");
        int layer = LayerMask.NameToLayer("PlayerHit");
        gameObject.layer = layer;
        if(dashDirection == 1) { // going right
            isDashing = true;
            dashVector = new Vector3(4, 0, 0);
            rbc.enabled = true;
        } else {
            isDashing = true;
            dashVector = new Vector3(-4, 0, 0);
            rbc.enabled = true;
        }
    }

    public void parry() {
        anim.SetTrigger("ShieldSwingTrigger");
        shield.GetComponent<ShieldAction>().handleParry();
        
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Skull") {
            isDashing = false;
            int layer = LayerMask.NameToLayer("PlayerNoHit");
            gameObject.layer = layer;
            col.gameObject.GetComponent<GroundEnemy>().Hit();
        }
    }

    public void die() {
        GameController.getInstance().resetGame();
    }


}
