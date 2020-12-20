using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    bool collectScroll;

    public GameObject text1, text2;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        text2.SetActive(false);
        timer = Time.time + 5f;
    }

    // Update is called once per frame
    void Update()
    {
     
        if(Time.time > timer)
        {
            text1.SetActive(false);
        }
        if(collectScroll == true && Time.time > timer)
        {
            text2.SetActive(false);
        }
    }
    public void setScrollActive()
    {
        collectScroll = true;
        timer = Time.time + 5f;
        text2.SetActive(true);
    }
}
