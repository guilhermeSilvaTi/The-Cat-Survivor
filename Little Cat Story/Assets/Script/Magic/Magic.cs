using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField]
    private int damageMagic = 15;
    //public bool blahVar {get; set;}
    [SerializeField]
    private int levelMagic = 2;

    public int level { private set => levelMagic = value; get => levelMagic; }

    public int damage { private set => damageMagic = value; get => damageMagic; }

    public void Active()
    {
        this.gameObject.SetActive(true);
    }
    public void Disabled()
    {
        this.gameObject.SetActive(false);
    }
       
}
