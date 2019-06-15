using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D myBody;

    public float moveSpeed = 2f;

    private float ScreenWidth;

    void Start()
    {
        ScreenWidth = Screen.width;
    }

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }
    
    
    void Update() {
        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                //move right
                myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
            }

            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //move left
                myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
            }

            ++i;
        }
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
     
        if(Input.GetAxisRaw("Horizontal") > 0f) {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }

        if (Input.GetAxisRaw("Horizontal") < 0f) {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }
    } // move

    public void PlatformMove(float x) {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }

} // class







































