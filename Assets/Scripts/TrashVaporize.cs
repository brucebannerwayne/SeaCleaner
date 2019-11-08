using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashVaporize : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)//Destroy the trash selected by instant recycle
    {
        if(collision.tag == "Trash")
        {
            collision.SendMessage("SelfDest");
            SelfDestory();
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
    
    public void SelfDestory()
    {
        Destroy(gameObject);
    }
}
