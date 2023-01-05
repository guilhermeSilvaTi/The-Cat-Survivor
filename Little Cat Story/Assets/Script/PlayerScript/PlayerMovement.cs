using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Player player;
   


    void FixedUpdate()
    {
        if (player.playerIsMove)
            WalkingAction();
        else
            player.playerRigidBody2D.velocity = Vector2.zero;

        switch (player.moving)
        {
            case Player.movingPlayer.Iddle:
                {
                    
                    break;
                }
            case Player.movingPlayer.Walking:
                {

                    break;
                }
        }
    }


    void WalkingAction()
    {
        
        player.playerRigidBody2D.velocity = player.velocityPlayerMove * player.velocity * Time.fixedDeltaTime;
    }
}
