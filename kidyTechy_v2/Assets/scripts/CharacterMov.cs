using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class CharacterMov : MonoBehaviour {
	float speed = 7;
	float gravity = 15;
	CharacterController controller;
	Vector3 moveDirection = Vector3.zero;
    GameObject boyObj;
    Animator anim;

    // Use this for initialization
    void Start () {
        boyObj = GameObject.Find("boy");
        anim = boyObj.GetComponent<Animator>();
        controller = transform.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		//APPLY GRAVITY
		if(moveDirection.y > gravity * -1) {
			moveDirection.y -= gravity * Time.deltaTime;
		}
		controller.Move(moveDirection * Time.deltaTime);
		var left = transform.TransformDirection(Vector3.left);

		if(controller.isGrounded) {
			if(Input.GetKeyDown(KeyCode.Space)) {
                anim.Play("jump1");
                moveDirection.y = speed;
			}
			else if(Input.GetKey(KeyCode.UpArrow)) {
                LeanTween.rotateY(boyObj, 0.0f, 0.5f);
                if (Input.GetKey(KeyCode.LeftShift)) {
                    anim.Play("walk");
                    controller.SimpleMove(transform.forward * speed);
				}
				else {
                    anim.Play("run");
                    controller.SimpleMove(transform.forward * speed * 3);
				}
			}
			else if(Input.GetKey(KeyCode.DownArrow)) {
                LeanTween.rotateY(boyObj, -180.0f, 0.5f);
                if (Input.GetKey(KeyCode.LeftShift)) {
                    anim.Play("walk");
                    controller.SimpleMove(transform.forward * speed);
                }
				else {
                    anim.Play("run");
                    controller.SimpleMove(transform.forward * speed * 3);
                }
			}
			else if(Input.GetKey(KeyCode.LeftArrow)) {
                LeanTween.rotateY(boyObj, -100.0f, 0.5f);
                if (Input.GetKey(KeyCode.LeftShift)) {
                    anim.Play("walk");
                    controller.SimpleMove(transform.forward * speed);
				}
				else {
                    anim.Play("run");
                    controller.SimpleMove(transform.forward * speed * 3);
				}
			}
			else if(Input.GetKey(KeyCode.RightArrow)) {
                LeanTween.rotateY(boyObj, -270.0f, 0.5f);
                if (Input.GetKey(KeyCode.LeftShift)) {
                    anim.Play("walk");
                    controller.SimpleMove(transform.forward * speed);
				}
				else {
                    anim.Play("run");
                    controller.SimpleMove(transform.forward * speed * 3);
				}
			}
		}
		else {
			if(Input.GetKey("w")) {
				Vector3 relative = new Vector3();
				relative = transform.TransformDirection(0, 0, 1);
				if(Input.GetKey(KeyCode.LeftShift)) {
					controller.Move(relative * Time.deltaTime * speed * 2);
				}
				else {
					controller.Move(relative * Time.deltaTime * speed);
				}
			}
		}
	}
}
