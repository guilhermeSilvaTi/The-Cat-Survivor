using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    SlotScreen[] slotScreens;

    void Update()
    {
        if(player.GetPlayerIsActive())
        {
            CheckController();
            TouchScreen();
            TouchMouse();
            KeyboardNumbersController();
        }   
    }

    private void KeyboardNumbersController()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotScreens[0].UsingSlot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotScreens[1].UsingSlot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotScreens[2].UsingSlot();
        }
    }

    private void TouchMouse()
    {
        if (Input.GetMouseButton(0))
        {
            // Vector3 mousePos = Input.mousePosition;
           // player.PlayerIsMoveGet(true);

            player.IsShootingGet(true);

            Vector2 comparationPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);



           /* if (transform.position.x <= comparationPosition.x)
                player.VelocityMoveX(-2);

            if (transform.position.x > comparationPosition.x)
                player.VelocityMoveX(2);

            if (transform.position.y >= comparationPosition.y)
                player.VelocityMoveY(2);

            if (transform.position.y < comparationPosition.y)
                player.VelocityMoveY(-2);
           */
        }
        else
        {
           // player.PlayerIsMoveGet(false);
            player.IsShootingGet(false);
        }

      //  if (Input.GetMouseButtonUp(0))
           

    }

    private void TouchScreen()
    {
        //touch
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {

                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);

                Vector2 comparationPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);


                if(transform.position.x < comparationPosition.x)
                {
                  //  player.VelocityMove(new Vector2(2, transform.position.y));
                }
                if (transform.position.x > comparationPosition.x)
                {
                  //  player.VelocityMove(new Vector2(-2, transform.position.y));
                }
                if (transform.position.y > comparationPosition.y)
                {
                   // player.VelocityMove(new Vector2(transform.position.x,-2));
                }
                if (transform.position.y < comparationPosition.y)
                {
                  //  player.VelocityMove(new Vector2(transform.position.x, 2));
                }
                /* if (hitInfo)
                 {
                     if (hitInfo.collider.gameObject == playerColliderCircle && releaseTime == 0)
                     {

                         StartCoroutine(circleGray());
                         moving = movingPlayer.TransformeToBall;
                     }

                 }*/


            }
        }
        //End touch
    }


    private void CheckController()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            player.PlayerIsMoveGet(true);
            player.VelocityMoveY(-2);          
        }

         if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        {
            player.PlayerIsMoveGet(true);
            player.VelocityMoveY(2);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            player.PlayerIsMoveGet(true);
            player.VelocityMoveX(2);
           
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            player.PlayerIsMoveGet(true);
            player.VelocityMoveX(-2);
           
        }


        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)
             || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            player.PlayerIsMoveGet(false);
            player.velocityPlayerMove = Vector2.zero;
         
        }
        /* LeftStick = base.GetButtonLeftStickValue();

         AnimalSwitch();

         switch (Player.Moving)
         {
             case MovingPlayer.Iddle:
                 {
                     CheckActionWhenPlayerIsIddle();
                     break;
                 }
             case MovingPlayer.Walking:
                 {
                     CheckActionWhenPlayerIsWalking();
                     break;
                 }
             case MovingPlayer.Jump:
                 {
                     CheckActionWhenPlayerIsJumping();
                     break;
                 }
             case MovingPlayer.DoubleJump:
                 {
                     CheckActionWhenPlayerIsDoubleJump();
                     break;
                 }
             case MovingPlayer.Fall:
                 {
                     CheckActionWhenPlayerIsFall();
                     break;
                 }
         }*/
    }

 
}
