using System.Collections;
using UnityEngine;

public class FlyingEnemyController : EntityController
{
    GameObject player;

    protected override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        base.Start();
    }

    private void Update()
    {
        if (!freeze)
        {
            this.transform.LookAt(player.transform);
            //if enemy can shoot player
            if (SeeObject(player))
                Shoot();
            else
                Move();

            //if enemy getted external interaction
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }

    protected override void Move()
    {
        this.transform.position += this.transform.forward * speed * Time.deltaTime;
        this.transform.position = new Vector3(this.transform.position.x, 6f, this.transform.position.z);
    }
}
