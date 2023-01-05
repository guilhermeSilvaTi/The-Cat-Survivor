using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    float positionMinY = -10.2f;
    float positionMaxY = 16.02f;

    float velocity = 5;

    bool IsRight;

   
    void Update()
    {
        if(IsRight && transform.position.y < positionMaxY)
        transform.Translate(Vector2.up * velocity * Time.deltaTime);
        else
        {
            IsRight = false;
         
            if (transform.position.y > positionMinY)
                transform.Translate(Vector2.down * velocity * Time.deltaTime);
            else
                IsRight = true;
        }
    }
}
