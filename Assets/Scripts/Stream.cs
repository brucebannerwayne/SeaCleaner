using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    public Vector2 streamForce;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Trash")
        {
            collision.SendMessage("FloatAround", streamForce);
            Debug.Log(streamForce);
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
