using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    uint gold = 0;
    [SerializeField]
    Text goldText;
    [SerializeField]
    Text hpText;
    [SerializeField]
    GameObject deadFrame;

    public void AddGold(uint value)
    {
        gold += value;
        goldText.text = "Gold: " + gold.ToString();
    }

    public uint GetGold()
    {
        return gold;
    }

    public override void Damage(int value)
    {
        hp -= value;
        hpText.text = "HP: " + hp.ToString();
        if (hp < 0)
        {
            hp = 0;
            hpText.text = "HP: " + hp.ToString();
            Die();
        }
    }

    protected override void Die()
    {
        deadFrame.SetActive(true);
        Time.timeScale = 0;
    }
}
