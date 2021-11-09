using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyController : EntityController
{
    GameObject player;
    NavMeshAgent navMeshAgent;

    protected override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
        base.Start();
    }

    private void Update()
    {
        if (!freeze)
        {
            this.transform.LookAt(player.transform);
            //if enemy can shoot player
            if (SeeObject(player))
            {
                navMeshAgent.SetDestination(this.transform.position);
                Shoot();
            }
            else
                Move();

            //if enemy getted external interaction
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }

    protected override void Move()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.Damage(damage);
        }
    }
}
