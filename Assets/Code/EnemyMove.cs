using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;

    public Animation anim;

    public bool isAttacking = false;

    public bool isAlive, canDisappear;

    public int health = 100;

    public GameObject targetedEnemy;

    public int aggroDistance;

    public float attackRange = 0.1f;

    Vector3 startingPosition, currentPosition;

    private float sinkTimer;

    private float stayTimer;


    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

        anim = gameObject.GetComponent<Animation>();

        isAlive = true;

        aggroDistance = 20;

        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = agent.velocity.magnitude / agent.speed;

        if (isAlive == true)
        {
            if (health <= 0)
            {
            //    Debug.Log("IsDead");
                anim.Play("death");
                isAlive = false;

                agent.SetDestination(this.transform.position);

                sinkTimer = Time.time + 10f;

            }

            else if (speed > 0f)
            {
            //    Debug.Log("IsWalking");
                anim.Play("walk");
            }

            else if (Vector3.Distance(targetedEnemy.transform.position, this.transform.position) <= attackRange)
            {
                isAttacking = true;
           //     Debug.Log("IsAttacking");
                anim.Play("attack");

            }
            else if (speed == 0f)
            {
            //    Debug.Log("IsChilling");
                anim.Play("free");
            }

            if (targetedEnemy.GetComponent<CharacterMove>().isAlive == false)
            {
                agent.SetDestination(startingPosition);
                Quaternion lookAt = Quaternion.LookRotation(startingPosition - transform.position);
            }

            else if (targetedEnemy.GetComponent<CharacterMove>().isAlive)
            {
                if (Vector3.Distance(targetedEnemy.transform.position, this.transform.position) < aggroDistance && Vector3.Distance(targetedEnemy.transform.position, this.transform.position) > attackRange)
                {

                    agent.SetDestination(targetedEnemy.transform.position);

                    Quaternion lookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);

                }

                else
                {
                    agent.SetDestination(this.transform.position);
                    Quaternion lookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
                }
            }
            

        }

        else if (isAlive == false)
        {

            if (Time.time > sinkTimer)
            {
                Debug.Log("It is working");

                currentPosition.y = currentPosition.y - 1f * Time.deltaTime;

                transform.position = currentPosition;


            }

            else if(canDisappear == false)
            {
                stayTimer = Time.time + 12f;

                canDisappear = true;
            }

            if(Time.time > stayTimer)
            {
                Destroy(this.gameObject);
            }

        }

        currentPosition = transform.position;
    }
}