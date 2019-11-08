﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grapple : MonoBehaviour
{
    public void SuperGrapple()//make grapple moves faster when super grapple button is pressed
    {
        GameObject.FindWithTag("Data").SendMessage("Strength");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
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
