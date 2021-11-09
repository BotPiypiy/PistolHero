using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyController : MonoBehaviour
{
    [SerializeField]
    float enemySpeed = 1;
    [SerializeField]
    float fireDelay = 1;
    float time = 0;
    Rigidbody rigidbody;
    GameObject player;
    NavMeshAgent navMeshAgent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = enemySpeed;
        rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        this.transform.LookAt(player.transform);
        //if enemy can shoot player
        if (seePlayer())
        {
            navMeshAgent.SetDestination(this.transform.position);
            Shoot();
        }
        else
            navMeshAgent.SetDestination(player.transform.position);

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    private bool seePlayer()
    {
        Debug.DrawRay(this.transform.position + this.transform.forward, this.transform.forward * 10, Color.yellow);
        Ray ray = new Ray(this.transform.position + this.transform.forward, this.transform.forward);
        RaycastHit rayHit;
        Physics.Raycast(ray, out rayHit);

        if (rayHit.collider.tag == "Player")
            return true;
        else
            return false;
    }

    private void Shoot()
    {
        Debug.Log("Pew-pew");
    }
}
