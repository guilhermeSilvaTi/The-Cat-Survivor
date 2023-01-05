using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesGame : MonoBehaviour
{
    public static int gold = 0;
    public static int levelGame = 1;
    public static int levelPlayer = 1;
    public static List<Hability> hability = new List<Hability>(18) { Hability.empty,Hability.empty, Hability.empty, Hability.empty, Hability.empty, Hability.empty,
        Hability.empty, Hability.empty, Hability.empty, Hability.empty, Hability.empty, Hability.empty,
        Hability.empty, Hability.empty, Hability.empty, Hability.empty, Hability.empty, Hability.empty };
    public static List<int> indexHabilityUsing = new List<int>();
    public static float music =0.3f;
    public static float sfx=0.3f;


  public static void ResetGame()
    {
        gold = 0;
    levelGame = 1;
     levelPlayer = 1;
     hability = new List<Hability>(18) { Hability.empty,Hability.empty, Hability.empty, Hability.empty, Hability.empty, Hability.empty,
        Hability.empty, Hability.empty, Hability.empty, Hability.empty, Hability.empty, Hability.empty,
        Hability.empty, Hability.empty, Hability.empty, Hability.empty, Hability.empty, Hability.empty };
     indexHabilityUsing = new List<int>();
}


   
}
