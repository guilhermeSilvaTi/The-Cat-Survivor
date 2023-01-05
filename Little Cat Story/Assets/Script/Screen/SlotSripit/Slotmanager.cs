using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slotmanager : MonoBehaviour
{
    List<GameObject> machineList = new List<GameObject>();

    [SerializeField]
   public GameObject[] habilityObject;
    [SerializeField]
   public Sprite[] spriteIcon;

    public void StopGame()
    {
        if (machineList.Count > 0)
        {
            foreach (var item in machineList)
                item.SetActive(false);
        }
    }

    public void AddObject(GameObject  objectAdd)
    {
        machineList.Add(objectAdd);
    }
}
