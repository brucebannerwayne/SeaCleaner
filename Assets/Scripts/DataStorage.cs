using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void ResetAll()
    {
        speed = 3.0f;
        stun = false;
        vaporize = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Strength() {
        speed = 5.0f;
      }
    public void StunFish()
    {
        stun = true;
    }
    public void GetVapor()
    {
        vaporize = 2;
    }
}
