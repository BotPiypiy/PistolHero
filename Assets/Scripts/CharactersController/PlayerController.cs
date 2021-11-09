using UnityEngine;

public class PlayerController : EntityController
{
    [SerializeField]
    Joystick joystick;
    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Move();
        }
        else
        {
            //save current rotation
            Quaternion currentRot = this.transform.rotation;

            if (LookAtEnemy())      //if we can see and shoot the enemy -> shoot
                Shoot();
            else                    //else we don't change the rotation
                this.transform.rotation = currentRot;
        }

        //if player getted external interaction
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    protected override void Move()
    {
        //moving player
        rigidbody.transform.position +=  new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized
            * speed * Time.fixedDeltaTime;
        //getting joystick angle
        float angle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal * -1 ) * Mathf.Rad2Deg - 90;
        //rotating player
        this.transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    private bool LookAtEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemies = SortEnemiesByDistance(enemies);

        //find enemy, that we can shoot
        for (uint i = 0; i < enemies.Length; i++)
        {
            this.transform.LookAt(enemies[i].transform);
            if (SeeObject(enemies[i]))
                return true;
        }
        return false;
    }

    private GameObject[] SortEnemiesByDistance(GameObject[] enemies)
    {
        GameObject temp;

        for (uint i = 0; i < enemies.Length - 1; i++)
        {
            for (uint j = i + 1; j < enemies.Length; j++)
            {
                if (Vector3.Distance(this.transform.position, enemies[i].transform.position) >
                    Vector3.Distance(this.transform.position, enemies[i].transform.position))
                {
                    temp = enemies[i];
                    enemies[i] = enemies[j];
                    enemies[j] = temp;
                }
            }
        }
        return enemies;
    }
}