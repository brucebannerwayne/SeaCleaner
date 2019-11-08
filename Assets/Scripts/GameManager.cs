﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    
    public int targetScore;
    public int trashType1;
    public int FishDead;
    public int trashType2;
    public int score;
    public Text scoreText;
    public Text timeCount;
    public int totalTime;
    private bool gameOver;
    public List<GameObject> FishCount = new List<GameObject>();
    public List<GameObject> TrashCount = new List<GameObject>();
    public bool win;
    public GameObject DataStorage;
    public GameObject trashDetect;
    public Vector3 de;
    // Start is called before the first frame update
    void Start()
    {
        win = false;
        gameOver = false;
        trashType1 = 0;
        FishDead = 0;
        trashType2 = 0;
        StartCoroutine(CountDown());
        DataStorage = GameObject.FindWithTag("Data");
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
       score = 50 * trashType1 + 150 * trashType2 - 100 * FishDead;//count score
       if(DataStorage.GetComponent<DataStorage>().stun == true)//Stun fish
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach(GameObject f in GameObject.FindGameObjectsWithTag("fish"))
                {
                    f.SendMessage("Stun");
                }
                DataStorage.GetComponent<DataStorage>().stun = false;
            }
        }
       if(DataStorage.GetComponent<DataStorage>().vaporize > 0)//instant recycle
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                
                de = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane));
                
                Instantiate(trashDetect, de, Quaternion.identity);
                DataStorage.GetComponent<DataStorage>().vaporize--;
            }
        }
        CountTrash();
        CountFish();
        UpdateScore();
        if(totalTime == 0)
        {
            gameOver = true;
        }
        if(score >= targetScore)
        {
            win = true;
        }
        if(gameOver == true)//winning determination
        {
            if(win == true)
            {
                DataStorage.SendMessage("ResetAll");
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            else
            {
                DataStorage.SendMessage("ResetAll");
                SceneManager.LoadScene("Fail");
            }
        }
             
    }
    public void AddTType1()//count the number of trash which worth 50 points
    {
        trashType1++;
    }
    public void AddTType2()//count the number of trash which worth 150 points
    {
        trashType2++;
    }
    public void AddFishDead()//count how many fish is dead
    {
        FishDead++;
    }
    public void UpdateScore()//update score
    {
        scoreText.text = "Score:" + score;
    }
    private IEnumerator CountDown()//time count
    {
        while(totalTime >= 0)
        {
            timeCount.text = "Time:" + totalTime.ToString();
            yield return new WaitForSeconds(1);
            totalTime--;
        }
    }
    public void CountFish()//count the surviving fish
    {
        FishCount.Clear();
        
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("fish"))
        {
            FishCount.Add(g);
        }
        FishCount.RemoveAll(item => item == null);
        if(FishCount.Count ==0)
        {
            gameOver = true;
            win = false;
            DataStorage.SendMessage("ResetAll");
            SceneManager.LoadScene("Fail");
        }
        
    }
    public void CountTrash()//count how many trashed are left
    {
        TrashCount.Clear();
        foreach(GameObject t in GameObject.FindGameObjectsWithTag("Trash"))
        {
            TrashCount.Add(t);
        }
        TrashCount.Add(GameObject.FindWithTag("Trash"));
        TrashCount.RemoveAll(item => item == null);
        if(TrashCount.Count == 0)
        {
            gameOver = true;
            win = true;
        }
        
    }
}
