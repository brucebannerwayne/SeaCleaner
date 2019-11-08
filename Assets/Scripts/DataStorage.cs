using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Store the data that won't be destroyed when loading a new scene
public class DataStorage : MonoBehaviour
{
    public float speed;
    public bool stun;
    public int vaporize;
    // Start is called before the first frame update
    void Start()
    {
        stun = false;
        GameObject.DontDestroyOnLoad(gameObject);
        speed = 3.0f;
        vaporize = 0;
    }
    public void ResetAll()//reset all the data when a level is finished
    {
        speed = 3.0f;
        stun = false;
        vaporize = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Strength() {//make grapple moves faster when super grapple is selected
        speed = 5.0f;
      }
    public void StunFish()//make the fish stun ability available
    {
        stun = true;
    }
    public void GetVapor()//make instant recycle available
    {
        vaporize = 2;
    }
}
