using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    int hp = 100;

    public void Damage(int value)
    {
        hp -= value;
    }
}
