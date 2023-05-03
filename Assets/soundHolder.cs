using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundHolder : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource sound;
    public void Start() {
        sound.Play();
    }
    public void Update() {
        if(!sound.isPlaying) {
            Destroy(gameObject);
        }
    }

}
