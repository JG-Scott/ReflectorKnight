using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrancePES : MonoBehaviour
{

    public ParticleSystem ps;
    public void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Fire") {
            ps.Play();
            GetComponent<AudioSource>().Play();
        }

    }
}
