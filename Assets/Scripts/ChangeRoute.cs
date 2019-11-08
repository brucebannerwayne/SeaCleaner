using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//make the fish patrol
public class ChangeRoute : MonoBehaviour
{
    public Transform Target;
    public Vector3 rotateDir = Vector3.zero;
    public Vector3 change = new Vector3(0, 180, 0);
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="fish")
        {
            
            collision.GetComponent<FishPatrol>().tr = Target;
            rotateDir = collision.GetComponent<FishPatrol>().rotDir + change;
            collision.GetComponent<FishPatrol>().rotDir = rotateDir;
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
