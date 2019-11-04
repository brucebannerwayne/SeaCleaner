using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerS6 : MonoBehaviour
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
    public float spawnWait;
    public float startWait;
    public float wavewait;
    public GameObject[] hazards;
    public int hazardCount;
    public Vector2 spawnValues;
    private Vector2 spawnPosition = Vector2.zero;
    private Quaternion spawnRotation;
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                spawnPosition.x = Random.Range(spawnValues.x, spawnValues.x+5);
                spawnPosition.y = Random.Range(spawnValues.y, spawnValues.y+2);
                spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(wavewait);
            if (gameOver)
            {

                break;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        win = false;
        gameOver = false;
        trashType1 = 0;
        FishDead = 0;
        trashType2 = 0;
        StartCoroutine(CountDown());
        StartCoroutine(SpawnWaves());
        DataStorage = GameObject.FindWithTag("Data");
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        score = 50 * trashType1 + 150 * trashType2 - 100 * FishDead;
        if (DataStorage.GetComponent<DataStorage>().stun == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (GameObject f in GameObject.FindGameObjectsWithTag("fish"))
                {
                    f.SendMessage("Stun");
                }
                DataStorage.GetComponent<DataStorage>().stun = false;
            }
        }
        if (DataStorage.GetComponent<DataStorage>().vaporize > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                de = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

               
                Instantiate(trashDetect, de, Quaternion.identity);
                DataStorage.GetComponent<DataStorage>().vaporize--;
            }
        }
        CountTrash();
        CountFish();
        UpdateScore();
        if (totalTime == 0)
        {
            gameOver = true;
        }
        if (score >= targetScore)
        {
            win = true;
        }
        if (gameOver == true)
        {
            if (win == true)
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
    public void AddTType1()
    {
        trashType1++;
    }
    public void AddTType2()
    {
        trashType2++;
    }
    public void AddFishDead()
    {
        FishDead++;
    }
    public void UpdateScore()
    {
        scoreText.text = "Score:" + score;
    }
    private IEnumerator CountDown()
    {
        while (totalTime >= 0)
        {
            timeCount.text = "Time:" + totalTime.ToString();
            yield return new WaitForSeconds(1);
            totalTime--;
        }
    }
    public void CountFish()
    {
        FishCount.Clear();

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("fish"))
        {
            FishCount.Add(g);
        }
        FishCount.RemoveAll(item => item == null);
        if (FishCount.Count == 0)
        {
            gameOver = true;
            win = false;
            DataStorage.SendMessage("ResetAll");
            SceneManager.LoadScene("Fail");
        }

    }
    public void CountTrash()
    {
        TrashCount.Clear();
        foreach (GameObject t in GameObject.FindGameObjectsWithTag("Trash"))
        {
            TrashCount.Add(t);
        }
        TrashCount.Add(GameObject.FindWithTag("Trash"));
        TrashCount.RemoveAll(item => item == null);
        if (TrashCount.Count == 0)
        {
            gameOver = true;
            win = true;
        }

    }
}
