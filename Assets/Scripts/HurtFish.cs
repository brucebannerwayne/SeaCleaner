using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script used to control trash
public class HurtFish : MonoBehaviour
{
    public GameObject dataStorage;
    public bool canMove;
    public float speed;
    public Transform tr;
    public bool lethal;
    public void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Hook")//make the grapple moves with the grapple
        {
            Freeze();
            gameObject.transform.parent = collision.gameObject.GetComponentInChildren<Transform>();
            collision.gameObject.SendMessage("MoveBack");
            collision.gameObject.SendMessage("HoldTight");
        }
       if(collision.tag =="fish"&& lethal == true)//hurt the fish
        {
            foreach(GameObject g in GameObject.FindGameObjectsWithTag("fish"))
            {
                g.SendMessage("SelfDest");
            }
        }
    }
    public void SelfDest()//destroy the trash and count the score
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
    public void GotEat()//trash got eaten by fish
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
        if(canMove == true)//allow trash to float
        {
            transform.position = Vector3.MoveTowards(transform.position, tr.position, speed * Time.deltaTime);
        }
    }
    public void FloatAround(Vector2 force)//trash float
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = force;
    }
    public void Freeze()//freeze the trash when it is touched by grapple
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        speed = 0;
    }
}
