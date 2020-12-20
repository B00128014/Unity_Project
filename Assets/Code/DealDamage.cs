using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    int dmg;

    public GameObject currentEnemy;

    public float attackCooldown;

    AudioSource hit;

    // Start is called before the first frame update
    void Start()
    {
        dmg = 10;
        currentEnemy = this.gameObject.GetComponentInParent<AttackEnemy>().targetedEnemy;
        attackCooldown = 0f;

        hit = gameObject.GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponentInParent<AttackEnemy>().targetedEnemy != null)
        {
            if (Vector3.Distance(this.gameObject.transform.position, this.gameObject.GetComponentInParent<AttackEnemy>().targetedEnemy.gameObject.GetComponent<CapsuleCollider>().transform.position) <= 2f && Time.time > attackCooldown && this.gameObject.GetComponentInParent<AttackEnemy>().targetedEnemy.GetComponent<EnemyMove>().health > 0)
            //if the distance between the player and the enemy is smaller than 2 units AND the enemy is still alive AND the attack cooldown expired, then:
            {
                this.gameObject.GetComponentInParent<AttackEnemy>().targetedEnemy.GetComponent<EnemyMove>().health = this.gameObject.GetComponentInParent<AttackEnemy>().targetedEnemy.GetComponent<EnemyMove>().health - dmg;

                attackCooldown = Time.time + 0.8f;

                hit.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == this.gameObject.GetComponentInParent<AttackEnemy>().targetedEnemy)
        {
            this.gameObject.GetComponentInParent<AttackEnemy>().targetedEnemy.GetComponent<EnemyMove>().health = this.gameObject.GetComponentInParent<AttackEnemy>().targetedEnemy.GetComponent<EnemyMove>().health - dmg;
        }
    }
}
