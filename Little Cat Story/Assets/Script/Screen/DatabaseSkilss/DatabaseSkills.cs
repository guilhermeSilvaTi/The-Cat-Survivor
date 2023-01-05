using UnityEngine;

public class DatabaseSkills : MonoBehaviour
{
    [SerializeField]
    string[] title;
    [SerializeField]
    string[] descriptions;
    [SerializeField]
    int[] gold;
    [SerializeField]
    Hability[] habilities;
    [SerializeField]
    int[] level;

    public string GetTittle(int value)
    {
        return title[value];
    }
    public string GetDescriptions(int value)
    {
        return descriptions[value];
    }
    public int GetGold(int value)
    {
        return gold[value];
    }
    public Hability GetHabilities(int value)
    {
        return habilities[value];
    }
 
}
