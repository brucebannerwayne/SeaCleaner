using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDestroy : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Trash")
        {
            collision.gameObject.SendMessage("SelfDest");
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
