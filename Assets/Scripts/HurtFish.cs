using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtFish : MonoBehaviour
{
    public GameObject dataStorage;
    public bool canMove;
    public float speed;
    public Transform tr;
    public bool lethal;
    public void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Hook")
        {
            Freeze();
            gameObject.transform.parent = collision.gameObject.GetComponentInChildren<Transform>();
            collision.gameObject.SendMessage("MoveBack");
            collision.gameObject.SendMessage("HoldTight");
        }
       if(collision.tag =="fish"&& lethal == true)
        {
            foreach(GameObject g in GameObject.FindGameObjectsWithTag("fish"))
            {
                g.SendMessage("SelfDest");
            }
        }
    }
    public void SelfDest()
    {
        if (lethal == false)
        {
            GameObject.FindWithTag("GameManager").SendMessage("AddTType1");
        }
        else
        {
            GameObject.FindWithTag("GameManager").SendMessage("AddTType2");
        }
        Destroy(gameObject);
    }
    public void GotEat()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, tr.position, speed * Time.deltaTime);
        }
    }
    public void FloatAround(Vector2 force)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = force;
    }
    public void Freeze()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        speed = 0;
    }
}
