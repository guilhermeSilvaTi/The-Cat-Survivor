using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    internal PlayerInput PlayerInput;
    [SerializeField]
    internal PlayerCollider PlayerCollider;
    [SerializeField]
    internal PlayerMovement PlayerMovement;

    internal enum movingPlayer { Iddle , Walking };
    internal movingPlayer moving;

    [SerializeField]
    internal Rigidbody2D playerRigidBody2D;

    [SerializeField]
    internal SpriteRenderer spriteRender;

    [SerializeField]
    internal BoxCollider2D boxCollider2D;

    [SerializeField]
    internal float velocity = 2;

    [SerializeField]
    internal Vector2 velocityPlayerMove;

    internal bool playerIsMove;

    internal bool isShooting;

    [SerializeField]
    Weapon weapon;

    //States Player
    
    public int life = 100;
    private int vitality = 100;
    public  int experience = 0;
    public  int maxLevelXp = 100;
    public  int level = 1;

    [SerializeField]
    Image ExpBar;
    [SerializeField]
    Image lifeBar;

    [SerializeField]
    bool playerActive = true;

    [SerializeField]
    EndGame endGame;
    private void Start()
    {
        XpBarGet();
    }

    public void VelocityMoveX(float vectorGet)
    {
        velocityPlayerMove = new Vector2(vectorGet, velocityPlayerMove.y);
    }
    public void VelocityMoveY(float vectorGet)
    {
        velocityPlayerMove = new Vector2( velocityPlayerMove.x, vectorGet);
    }
    internal void PlayerIsMoveGet(bool value)
    {
        playerIsMove = value;          
    }
    internal void PlayerIsActive(bool value)
    {
        playerActive = value;
        if (!value)
        {
            IsShootingGet(false);
            PlayerIsMoveGet(false);
        }
    }
    public bool GetPlayerIsActive()
    {
        return playerActive;
    }
    internal void IsShootingGet(bool value)
    {
        isShooting = value;
       weapon.Active(value);
    }

    public void GetExp(int xp)
    {

        experience += xp;

        while (experience >= maxLevelXp)
        {
            experience -= maxLevelXp;
            level++;
            StatesGame.levelPlayer = level;
            maxLevelXp += 100;
            // xpSoundLevelup.Play();
        }
        if (experience < 0)
            experience = 0;

        XpBarGet();
    }
    private void XpBarGet()
    {
        float valueXp = 100 * experience;
        valueXp = valueXp / maxLevelXp;

        valueXp /= 100;
        ExpBar.fillAmount = valueXp;
    }
    public void GetDamage(int valueDamage)
    {
        life -= valueDamage;
        LifeBarGet();
    }
    public IEnumerator GetFreeze()
    {
        float oldVelocity = velocity;
        velocity = velocity/2;
        spriteRender.color = Color.blue;
        yield return new WaitForSeconds(1.4f);
        spriteRender.color = Color.white;
        velocity = oldVelocity;
    }
    public void LifeBarGet()
    {
        if (life > vitality)
            life = vitality;

        float valuelife = 100 * life;
        valuelife = valuelife / vitality;

        valuelife /= 100;
        lifeBar.fillAmount = valuelife;

        if (life <= 0)
            ResetThisGame();
    }

    private void ResetThisGame()
    {
        playerActive = false;
        spriteRender.sprite = null;
        PlayerIsMoveGet(false);
        playerRigidBody2D.isKinematic = true;
        boxCollider2D.enabled = false;
        StartCoroutine(endGame.LevelIsEnd());
     
    }

    public void Healing(int value)
    {
        if (life < vitality)
            life += value;

        LifeBarGet();
    }
}
