using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    Player player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    protected override void Die()
    {
        player.AddGold(((uint)Random.Range(1, 11)));
        base.Die();
    }
}
