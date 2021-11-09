using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    protected int hp = 100;

    public virtual void Damage(int value)
    {
        hp -= value;
        if (hp < 1)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
