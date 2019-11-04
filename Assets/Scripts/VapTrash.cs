using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VapTrash : MonoBehaviour
{
    public GameObject dataStorage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dataStorage.GetComponent<DataStorage>().vaporize > 0)
        {
            Ray vapor = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(vapor,out hit))
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if(hit.collider.gameObject.tag == "Trash")
                    {
                        hit.collider.gameObject.SendMessage("SelfDest");
                        dataStorage.GetComponent<DataStorage>().vaporize--;
                    }
                }
            }
        }
    }
}
