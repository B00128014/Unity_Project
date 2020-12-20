using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpike : MonoBehaviour
{
    public Vector3 startingPosition, currentPosition;

    float lifeTime;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        lifeTime = Time.time + 5f;
        
    }

    // Update is called once per frame
    void Update()
    {

        currentPosition.x = startingPosition.x;
        currentPosition.z = startingPosition.z;
        currentPosition.y = currentPosition.y + 0 * Time.deltaTime;

        transform.position = new Vector3(currentPosition.x, currentPosition.y,currentPosition.z);
        
        
        if (Time.time > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }


    public void StartingPosition(Vector3 startingPos)
    {
        startingPosition.y = startingPos.y - 5f;

        startingPosition.x = startingPos.x;

        startingPosition.z = startingPos.z;
    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.gameObject.GetComponent<EnemyMove>().health = collision.collider.gameObject.GetComponent<EnemyMove>().health - 30;
    }
}
