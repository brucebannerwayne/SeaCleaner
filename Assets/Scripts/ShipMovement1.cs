using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement1 : MonoBehaviour
{
    public float speed;
    public float xMin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(h, 0, 0);
        GetComponent<Rigidbody2D>().velocity = movement * speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5, 5), 0, 0);
    }
}
