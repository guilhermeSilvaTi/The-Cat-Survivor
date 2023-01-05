using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Buyitem : MonoBehaviour
{
    [SerializeField]
    int goldRequired = 300;

    [SerializeField]
    TextMeshProUGUI[] textTitleDescGold;

    [SerializeField]
    StoreWindows storeWindows;

    private int indexHability;

    private Hability hability;

    [SerializeField]
    Image colorButton;
    [SerializeField]
    bool disabledButton;

    [SerializeField]
    SlotScreen slotScreens;

    [SerializeField]
    Weapon weapon;

    [SerializeField]
    AudioSource[] sounds;
    public void SetValuesText(int gold, string title, string desc,Hability hability, int indexHability)
    {
        goldRequired = gold;
        textTitleDescGold[0].text = title;
        textTitleDescGold[1].text = desc;
        textTitleDescGold[2].text = gold.ToString();
        this.hability = hability;
        this.indexHability = indexHability;
    }
    public void BuyItem()
    {
        if (StatesGame.gold >= goldRequired && !disabledButton)
        {

            StatesGame.hability[indexHability] = hability;
            StatesGame.gold -= goldRequired;

            CheckTypebuyItem();
            sounds[0].Play();

            disabledButton = true;
            colorButton.color = Color.gray;
            storeWindows.UpdateGold();
        }
        else
        {
            colorButton.color = Color.red;
            sounds[1].Play();
        }
    }

    private void CheckTypebuyItem()
    {
        switch(hability)
        {
            case Hability.Magnet: StatesGame.indexHabilityUsing.Add(indexHability); break;
            case Hability.Upgrate: StatesGame.indexHabilityUsing.Add(indexHability); break;
            case Hability.Trap: slotScreens.SetValueSlot(indexHability, hability); break;
            case Hability.Weapon: weapon.TradeWeapon(indexHability);break;
        }
                
    }

    public void CheckGold()
    {
        if (StatesGame.gold < goldRequired )
            colorButton.color = Color.gray;
        else
        {
            disabledButton = false;
            colorButton.color = Color.white;
        }
        foreach(var item in StatesGame.indexHabilityUsing)
        {
            if(indexHability == item)
            {
                disabledButton = true;
                colorButton.color = Color.gray;
                break;
            }
        }

    }
}
