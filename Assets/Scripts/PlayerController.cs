using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 1;
    [SerializeField]
    Joystick joystick;
    [SerializeField]
    float fireDelay = 1;
    float time = 0;
    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
            Move();
        else
            Shoot();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    private void Move()
    {
        //moving player
        this.transform.position +=  new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized
            * playerSpeed * Time.deltaTime;
        //getting joystick angle
        float angle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal * -1 ) * Mathf.Rad2Deg - 90;
        //rotating player
        this.transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    private void Shoot()
    {

    }
}