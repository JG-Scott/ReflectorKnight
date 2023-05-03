using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem ps;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!ps.isPlaying) {
            Destroy(gameObject);
        }
        
    }
}
