using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed;
    public bool canmove;

   
    void Update()
    {
        canmove = GameObject.FindWithTag("Hook").GetComponent<RotateHook>().canLaunch;
        if (canmove == true)
        {
            float h = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(h, 0, 0);
            GetComponent<Rigidbody2D>().velocity = movement * speed;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5, 5), 3.34f, 0);
        }
    }
}
