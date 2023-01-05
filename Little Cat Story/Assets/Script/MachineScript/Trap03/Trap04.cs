using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap04 : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D boxCollider2D;


    [SerializeField]
    float timeEnabled;

    float time;

    bool isActive;

    void Update()
    {
        time += Time.deltaTime;

        if(time >= timeEnabled)
        {

            time = 0;
            if (!isActive)
                boxCollider2D.enabled = true;
            else
                boxCollider2D.enabled = false;

        }
    }
}
