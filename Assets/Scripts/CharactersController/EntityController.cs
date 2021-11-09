using System.Collections;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    [SerializeField]
    protected float speed = 1;
    [SerializeField]
    protected float fireDelay = 1;
    protected float time = 0;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected GameObject bulletPrefab;
    float shootDistance = 50;
    protected Rigidbody rigidbody;
    [SerializeField]
    private float freezeTime = 1;
    protected bool freeze = true;

    protected virtual void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        StartCoroutine(WaitFor(freezeTime));
    }
    
    protected IEnumerator WaitFor(float sec)
    {
        yield return new WaitForSeconds(sec);
        freeze = false;
    }

    protected abstract void Move();

    protected void Shoot()
    {
        if (Time.time >= time)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.transform.position + this.transform.forward * 3.5f,
                this.transform.rotation);
            bullet.GetComponent<Bullet>().SetDamage(damage);
            time = Time.time + fireDelay;
        }
    }

    protected bool SeeObject(GameObject gameObject)
    {
        if (IsObjectOnRay(gameObject, 0.75f) && IsObjectOnRay(gameObject, 0f) && IsObjectOnRay(gameObject, -0.75f)
            && IsObjectOnRay(gameObject, 0, 0.75f) && IsObjectOnRay(gameObject, 0, -0.75f))
            return true;
        else
            return false;
    }

    protected bool IsObjectOnRay(GameObject gameObject, float offsetX, float offsetY = 0, float offsetZ = 1)
    {
        //creating ray(with offsets) and getting all hits
        Vector3 origin = this.transform.position + this.transform.forward * offsetZ + this.transform.up * offsetY
            + this.transform.right * offsetX;
        //Debug.DrawRay(origin, this.transform.forward * shootDistance, Color.yellow);
        Ray ray = new Ray(origin, this.transform.forward);
        LayerMask layer = LayerMask.GetMask("Default");
        RaycastHit[] rayHits = Physics.RaycastAll(ray, shootDistance, layer, QueryTriggerInteraction.Ignore);

        //finding distance between this object and needed object
        float distance = 0;
        for (uint i = 0; i < rayHits.Length; i++)
        {
            if (rayHits[i].collider.name.Contains(gameObject.name))
            {
                distance = Vector3.Distance(origin, rayHits[i].transform.position);
                break;
            }
        }

        //finding objects between thsise enemy and needed, and if it is -> return false
        for (uint i = 0; i < rayHits.Length; i++)
            if (Vector3.Distance(origin, rayHits[i].transform.position) < distance)
                return false;

        return true;
    }
}
