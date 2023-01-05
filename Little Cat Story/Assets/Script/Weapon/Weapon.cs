using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Transform[] pointStartShoot;

    [SerializeField]
    GameObject[] shootGetObject;

    [SerializeField]
    List<Shoot> shootList;

    int valueShoot;

    bool activeShoot;

    float timeShootCount = 0.4f;
    int damage = 35;
    int numberOfShootFPS = 1;
    int countFire;

    float time;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    DatabaseWeapon databaseWeapon;

    [SerializeField]
    Player player;

    [Header("Sons Armas")]
    [SerializeField]
    AudioSource[] gunsSound;
    int soundGunUsing;
    private void Start()
    {
        shootGetObject = GameObject.FindGameObjectsWithTag("Shoot");

        for (int i = 0; i < shootGetObject.Length; i++)
        {
            shootList.Add(shootGetObject[i].GetComponent<Shoot>());
            shootGetObject[i].SetActive(false);
        }
    }

    void Update()
    {
        if (player.GetPlayerIsActive())
        {
            RotationWeapon();
            ShootingActive();
        }
    }

    void RotationWeapon()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.right = direction;

        if (mousePosition.x < transform.position.x)
            spriteRenderer.flipY = true;
        else
            spriteRenderer.flipY = false;

    }
    public void Active(bool valueActive)
    {
        activeShoot = valueActive;
    }

    private void ShootingActive()
    {
        if (activeShoot)
        {
            time += Time.deltaTime;

            if (time >= timeShootCount)
            {
                Fire();
                time = 0;
            }

        }
    }
    private void Fire()
    {
        while (countFire < numberOfShootFPS)
        {

            if (damage == shootList[valueShoot].damage)
            {
                shootList[valueShoot].transform.position = new Vector2(pointStartShoot[countFire].transform.position.x, pointStartShoot[countFire].transform.position.y);
                shootList[valueShoot].transform.right = pointStartShoot[countFire].right;
                shootList[valueShoot].Active();
                gunsSound[soundGunUsing].Play();
                countFire++;
            }

            if (valueShoot < shootList.Count - 1)
                valueShoot++;
            else
                valueShoot = 0;

        }

        countFire = 0;
    }

    public void TradeWeapon(int value)
    {
        value -= 8;

        spriteRenderer.sprite = databaseWeapon.GetSprite(value);
        timeShootCount = databaseWeapon.GetTimeShootCount(value);
        numberOfShootFPS = databaseWeapon.GetFPS(value);
        damage = databaseWeapon.GetDamage(value);
        soundGunUsing = databaseWeapon.GetSound(value);

    }

}
