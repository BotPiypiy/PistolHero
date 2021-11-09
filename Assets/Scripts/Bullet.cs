using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 10;
    int damage;

    void Update()
    {
        this.transform.position += this.transform.forward.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.name.Contains("Bullet"))
        {
            if (other.GetComponent<Entity>())
                other.GetComponent<Entity>().Damage(damage);
            Destroy(this.gameObject);
        }
    }

    public void SetDamage(int value)
    {
        damage = value;
    }
}
