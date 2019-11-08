using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script used to control the grapple
public class RotateHook : MonoBehaviour
{
    public float angle;
    public float speed;
    public Transform rotatePoint;
    Vector3 rotatePole = Vector3.zero;
    public bool goBack;
    public bool canLaunch;
    public Transform anchor;
    public float tempAngle;
    public float weight;
    public Sprite loose;
    public Sprite tight;
    public GameObject dataStorage;
    // Start is called before the first frame update
    void Start()
    {
        rotatePole = Vector3.forward;
        canLaunch = true;
        angle = 90;
        goBack = false;
        dataStorage = GameObject.FindWithTag("Data");
        speed = dataStorage.GetComponent<DataStorage>().speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canLaunch == true)//rotate the grapple
        {
            transform.position = anchor.position;
            transform.RotateAround(rotatePoint.position, rotatePole, angle * Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && canLaunch == true)//Launch the grapple
        {
            canLaunch = false;
          
            tempAngle = angle;
            angle = 0;
            Vector3 moveDir = -transform.up;
            Debug.Log(moveDir);
            weight = 5.0f;
            GetComponent<Rigidbody2D>().velocity = moveDir * weight;

        }
        if (canLaunch == false && goBack ==true)//make the grapple come back
        {
            if (transform.position == anchor.position)
            {
               
                canLaunch = true;
                angle = tempAngle;
                goBack = false;
                GetLoose();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, anchor.position, speed * Time.deltaTime);
            }
        }
    }
    public void MoveBack()//pause the grapple and allow it to move back
    {
        goBack = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
       
        
    }
    public void HoldTight()//change the picture of the hook
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = tight;
    }
    public void GetLoose()//change the picture of the hook
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = loose;
    }
}
