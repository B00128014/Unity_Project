using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{

    public float attackRange, coolDown, abilityReady;

   
    

    public GameObject targetedEnemy, Prefab;


    // Start is called before the first frame update
    void Start()
    {
        attackRange = 1.0f;

        coolDown = 1.0f;

        abilityReady = 0f;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (targetedEnemy != null && targetedEnemy.GetComponent<EnemyMove>().isAlive == true)
        {
            if (Vector3.Distance(this.transform.position, targetedEnemy.transform.position) > attackRange)
            {
                this.gameObject.GetComponent<CharacterMove>().agent.SetDestination(targetedEnemy.transform.position);

                Quaternion lookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
            }

            else if (Vector3.Distance(this.transform.position, targetedEnemy.transform.position) <= attackRange)
            {
                this.gameObject.GetComponent<CharacterMove>().agent.SetDestination(this.transform.position);

                this.gameObject.GetComponent<CharacterMove>().isAttacking = true;

                Quaternion lookAt = Quaternion.LookRotation(targetedEnemy.transform.position);
            }
            else
            {
                this.gameObject.GetComponent<CharacterMove>().agent.SetDestination(this.transform.position);

              //  this.gameObject.GetComponent<CharacterMove>().isAttacking = false;
            }
        }
        else if(targetedEnemy != null && targetedEnemy.GetComponent<EnemyMove>().isAlive == false)
        {
            this.gameObject.GetComponent<CharacterMove>().agent.SetDestination(this.transform.position);
            this.gameObject.GetComponent<CharacterMove>().isAttacking = false;
        }
        
    }
}
