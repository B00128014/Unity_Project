using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMove : MonoBehaviour
{
    public NavMeshAgent agent;

    public Animation anim;

    public bool isAttacking = false;

    public bool isAlive, scrollPickUp;

    public int health = 100;

    public GameObject Spike;

    public Vector3 spawnPos;

    float abilityReady;


    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

        anim = gameObject.GetComponent<Animation>();

        isAlive = true;

        abilityReady = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = agent.velocity.magnitude / agent.speed;

        if (isAlive)
        {
            if (health <= 0)
            {
             //   Debug.Log("IsDead");
                anim.Play("death");
                isAlive = false;

                agent.SetDestination(this.transform.position);

            }

            else if (speed > 0f)
            {
            //    Debug.Log("IsWalking");
                anim.Play("walk");
            }

            else if (isAttacking == true)
            {
             //   Debug.Log("IsAttacking");
                anim.Play("attack");

            }
            else if (speed == 0f)
            {
             //   Debug.Log("IsChilling");
                anim.Play("free");
            }

            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject.name == "Enemy1")
                    {
                        Debug.Log("Finally");

                        this.gameObject.GetComponent<AttackEnemy>().targetedEnemy = hit.collider.gameObject;

                        agent.SetDestination(hit.point);

                        Quaternion lookAt = Quaternion.LookRotation(hit.point - transform.position);
                    }
                    else
                    {
                        this.gameObject.GetComponent<AttackEnemy>().targetedEnemy = null;

                        agent.SetDestination(hit.point);

                        Quaternion lookAt = Quaternion.LookRotation(hit.point - transform.position);
                    }
                }
            }

        }
    }

    private void LateUpdate()
    {
        if (scrollPickUp)
        {
            if (Time.time > abilityReady)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;

                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                    {
                        //    if (hit.collider.gameObject.name == "Enemy1")
                        //  {
                        Debug.Log("CoolDown");

                        spawnPos = hit.point;
                        Spike.GetComponent<EarthSpike>().StartingPosition(spawnPos);

                        Instantiate(Spike);

                        abilityReady = Time.time + 5f;

                    }
                }
            }
        }
    }
    
}
