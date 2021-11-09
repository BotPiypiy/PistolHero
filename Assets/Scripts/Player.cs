using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    uint gold = 0;

    public void AddGold(uint value)
    {
        gold += value;
    }

    public uint GetGold()
    {
        return gold;
    }
}
