using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//script used to control fish
public class FishPatrol : MonoBehaviour
{
    public List<Transform> Path = new List<Transform>();
    public Transform tr;
    public int health;
    public float speed;
    public float rotSpeed;
    public Vector3 rotDir;
    public Sprite spriteAlarm;
    public Sprite spriteBlank;
    public GameObject sign;
    public GameObject dataStorage;
    public float tempSpeed;
    public bool eater;
    public bool fragile;
  
    // Start is called before the first frame update
    void Start()
    {
        health = 100;//set fish's hp based on its type
        if(fragile == true)
        {
            health = 32;
        }
        else if(eater == true)
        {
            health = 150;
        }
        rotSpeed = 2.0f;
        dataStorage = GameObject.FindWithTag("Data");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, tr.position, speed * Time.deltaTime);//make the fish patrol
        transform.rotation = Quaternion.Euler(rotDir);
        if (health <= 0)
        {
            SelfDest();
        }
    }
    public void SelfDest()//destroy the fish when it is dead and count the score
    {
        GameObject.FindWithTag("GameManager").SendMessage("AddFishDead");
        gameObject.tag = "Useless";
        Destroy(gameObject);
    }
    public void GetHurt()//notice the player that the fish got hurt
    {
        sign.GetComponent<SpriteRenderer>().sprite = spriteAlarm;
        Invoke("BackToNormal", 2);
    }
    public void BackToNormal()
    {
        sign.GetComponent<SpriteRenderer>().sprite = spriteBlank;
    }
    public void OnTriggerEnter2D(Collider2D collision)//hurt the fish when it contacts with trash
    {
        if(collision.tag == "Trash")
        {
            GetHurt();
            health -= 34;
            if(eater == true)
            {
                collision.SendMessage("GotEat");
            }
        }
    }
    public void Stun()//stun the fish
    {
        tempSpeed = speed;
        speed = 0;
        Invoke("Resume", 10);    
    }
    public void Resume()
    {
        speed = tempSpeed;
    }
}
