using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeft : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)//rotate the hook
    {
        if (collision.tag == "Hook")
        {
            collision.GetComponent<RotateHook>().angle = -90;
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
