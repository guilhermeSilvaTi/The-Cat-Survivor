using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreWindows : MonoBehaviour
{
    [SerializeField]
    Buyitem[] buyitem = new Buyitem[3];

    [SerializeField]
    private int[] valueRandomNumber = new int[3];

    [SerializeField]
    DatabaseSkills databaseSkills;

    int indexMax = 13;

    [SerializeField]
    ManagerGame managerGame;

    [SerializeField]
    Slotmanager slotmanager;

    [SerializeField]
    AudioSource[] sounds;
  
    public void Active()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
        slotmanager.StopGame();
        int[] oldValue = new int[3] { 0, 0, 0 };
        sounds[0].Play();
        oldValue[0] = valueRandomNumber[0];
        oldValue[1] = valueRandomNumber[1];
        oldValue[2] = valueRandomNumber[2];
        //if (StatesGame.indexHabilityUsing.Count < (indexMax-3))
        {
            for (int i = 0; i < valueRandomNumber.Length; i++)
            {
                while (valueRandomNumber[i] == 0)
                {
                    int valeuRandom = Random.Range(1, indexMax);
                    bool isUsing = false;
                    for (int t = 0; t < StatesGame.indexHabilityUsing.Count; t++)
                    {
                        if (valeuRandom == StatesGame.indexHabilityUsing[t])
                        {
                            isUsing = true;
                            break;
                        }
                    }
                    if (valeuRandom == oldValue[1] || valeuRandom == oldValue[0] || valeuRandom == oldValue[2]
                        || valeuRandom == valueRandomNumber[0] || valeuRandom == valueRandomNumber[1] || valeuRandom == valueRandomNumber[2])
                        isUsing = true;

                    if (!isUsing)
                    {                     
                        valueRandomNumber[i] = valeuRandom;
                    }

                }
            }

            for (int i = 0; i < valueRandomNumber.Length; i++)
            {
                buyitem[i].SetValuesText(databaseSkills.GetGold(valueRandomNumber[i]), databaseSkills.GetTittle(valueRandomNumber[i]),
                     databaseSkills.GetDescriptions(valueRandomNumber[i]), databaseSkills.GetHabilities(valueRandomNumber[i]), valueRandomNumber[i]);

                buyitem[i].CheckGold();
                valueRandomNumber[i] = 0;
            }
            
        }
    }

    public void Disabled()
    {
        sounds[1].Play();
        this.gameObject.SetActive(false);

    }

    public void UpdateGold()
    {
        managerGame.UpdateGold();
        
    }

}
