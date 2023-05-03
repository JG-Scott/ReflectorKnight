using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundHandler : MonoBehaviour
{

    public AudioSource swing;

    public AudioSource parry;
     public AudioSource hurt;

    // Start is called before the first frame update

    public void playSwing() {
        swing.Play();

    }
    public void playParry() {
        parry.Play();
    }

    public void playHurt() {
        hurt.Play();
    }
}
