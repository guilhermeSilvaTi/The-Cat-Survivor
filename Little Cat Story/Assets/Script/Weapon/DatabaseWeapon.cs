using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseWeapon : MonoBehaviour
{
    [Header("Time between shoot")]
    [SerializeField]
    float[] timeShootCount;

    [SerializeField]
    Sprite[] sprites;

    [Header("Number of Shoot")]
    [SerializeField]
    int[] FPS;

    [Header("This Should be in script Weapon")]
    [SerializeField]
    int[] damage;

    [Header("Sound Guun")]
    [SerializeField]
    int[] soundGun;

    public Sprite GetSprite(int value)
    {
        return sprites[value];
    }
    public float GetTimeShootCount(int value)
    {
        return timeShootCount[value];
    }
    public int GetFPS(int value)
    {
        return FPS[value];
    }
    public int GetDamage(int value)
    {
        return damage[value];
    }

    public int GetSound(int value)
    {
        return soundGun[value];
    }
    
}
