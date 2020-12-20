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

        lifeTime = Time.time + 2f;
        
    }

    // Update is called once per frame
    void Update()
    {

        currentPosition.x = startingPosition.x;
        currentPosition.z = startingPosition.z;
        if (currentPosition.y < 1.8)
        {
            currentPosition.y = currentPosition.y + 35 * Time.deltaTime;
        }
        transform.position = new Vector3(currentPosition.x, currentPosition.y,currentPosition.z);
        
        
        if (Time.time > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }


    public void StartingPosition(Vector3 startingPos)
    {
        currentPosition.y = startingPos.y - 5f;

        startingPosition.x = startingPos.x;

        startingPosition.z = startingPos.z;

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag =="Enemy")
        {
            other.gameObject.GetComponent<EnemyMove>().health = other.gameObject.GetComponent<EnemyMove>().health - 30;
        }
        
    }
}
