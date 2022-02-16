using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected int gold = 0;
    public GameManager()
    {

    }

    public static void AddGold(int _gold)
    {
        GetInstance().gold += _gold;
    }


}
