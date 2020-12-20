using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public GameObject player;
    public float xSpeed, ySpeed, zSpeed, destroyDistance;

    // Start is called before the first frame update
    void Start()
    { 
        xSpeed = 5.0f;

        ySpeed = 20.0f;

        zSpeed = 50.0f;

        destroyDistance = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);

        if(Vector3.Distance(player.transform.position, this.transform.position) < destroyDistance)
            //is the player gets closer to the scroll than the destroyDistance, the player will pick up the scroll, and the game object will be destroyed
        {
            player.GetComponent<CharacterMove>().scrollPickUp = true;
            player.GetComponentInChildren<Canvas>().GetComponent<Instructions>().setScrollActive();
            Destroy(this.gameObject);
        }

        
    }
}
