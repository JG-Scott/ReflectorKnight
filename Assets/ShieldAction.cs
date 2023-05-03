using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAction : MonoBehaviour
{
    // Start is called before the first frame update

    public BoxCollider2D bc;

    public float colliderTimer = 0.5f;

    public Transform baseTransform;

    public Transform endTransform;

    public Animator playerAnim;
    public float parryCooldown = 1;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    void Update() {
        if(bc.enabled) {
            colliderTimer -= Time.deltaTime;
            if(colliderTimer <= 0) {
                bc.enabled = false;
                colliderTimer = 0.5f;

            }
        }
    }

    public void handleParry() {
        Debug.Log("Parry");
        bc.enabled = true;

    }

    

    public void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col.tag);
        if(col.tag == "SkullFlying") {
             col.gameObject.GetComponent<GroundEnemy>().changeDirection(endTransform.position - baseTransform.position);
        }
    }
}
