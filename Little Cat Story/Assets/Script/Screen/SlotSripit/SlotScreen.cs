using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScreen : MonoBehaviour
{
    [SerializeField]
    int valueSlot;

    Transform playerPosition;
    [SerializeField]
    Slotmanager slotmanager;

    [SerializeField]
    SpriteRenderer imageIcon;

    int numberUsing;
    int numberMax = 4;

    Hability hability;
    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void UsingSlot()//Calling in Button
    {
        if (hability == Hability.Trap)
        {
            if (numberUsing < numberMax)
            {
                GameObject getObject = Instantiate(slotmanager.habilityObject[valueSlot], new Vector3(playerPosition.position.x, playerPosition.position.y, 0), transform.rotation);
                getObject.transform.position = new Vector2(playerPosition.position.x, playerPosition.position.y);
                slotmanager.AddObject(getObject);
                numberUsing++;
                if (numberUsing >= numberMax)
                {
                    valueSlot = 0;
                    imageIcon.sprite = slotmanager.spriteIcon[valueSlot];
                    hability = Hability.empty;
                }
            }
        }
    }

    public void SetValueSlot(int value, Hability habilityGet)
    {
        if (habilityGet == Hability.Trap )
        {
            numberUsing = 0;
            valueSlot = value;
            imageIcon.sprite = slotmanager.spriteIcon[valueSlot];
            hability = habilityGet;
        }
    }
}
