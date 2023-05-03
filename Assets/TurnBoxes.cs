using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBoxes : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Skull") {
            col.gameObject.GetComponent<GroundEnemy>().Hit();
        }
    }
}
