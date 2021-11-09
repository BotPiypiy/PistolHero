using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyController : EntityController
{
    Rigidbody rigidbody;
    GameObject player;
    NavMeshAgent navMeshAgent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
        rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update()
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

    protected override void Move()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }
}
