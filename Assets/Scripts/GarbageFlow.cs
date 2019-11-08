using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageFlow : MonoBehaviour
{
    public Transform tr;
    public void OnTriggerEnter2D(Collider2D collision)//make garbage float
    {
        if(collision.tag == "Trash")
        {
            if(collision.GetComponent<HurtFish>().canMove == true)
            {
                collision.GetComponent<HurtFish>().tr = tr;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
