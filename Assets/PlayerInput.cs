using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private PlayerAction pa;


    // Start is called before the first frame update
    void Start()
    {
        pa = GetComponent<PlayerAction>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            pa.Move(new Vector3(-1*Time.deltaTime, 0, 0), 2);
        } 

        if(Input.GetKey(KeyCode.D)){
            pa.Move(new Vector3(1*Time.deltaTime, 0, 0), 1);
        }

        if(Input.GetKeyUp(KeyCode.D) ||Input.GetKeyUp(KeyCode.A) ) {
            pa.anim.SetBool("IsMoving", false); 
        }

        if(GameController.getInstance().getControllerType()) {
            if(Input.GetKey(KeyCode.RightArrow)) {
                pa.MoveArrow("right");
            }

            if(Input.GetKey(KeyCode.LeftArrow)) {
                pa.MoveArrow("left");
            }

            if(Input.GetKeyDown(KeyCode.Space)) {
                pa.parry();
            }

            if(Input.GetKeyDown(KeyCode.LeftShift)){
                pa.dash();
            }
        } else {

            if(Input.GetMouseButtonDown(0)) {
                pa.parry();
            }

            if(Input.GetKeyDown(KeyCode.Space)){
                pa.dash();
            }
        }
        if(Input.GetKeyDown(KeyCode.M)) {
            GameController.getInstance().playMusic = !GameController.getInstance().playMusic;
        }
    }
}
