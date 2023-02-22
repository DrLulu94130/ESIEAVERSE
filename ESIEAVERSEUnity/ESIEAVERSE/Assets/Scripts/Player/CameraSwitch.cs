using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public int ActiveCam;
    public int ListSize;
    public GameObject[] List;
    // Start is called before the first frame update
    void Start()
    {
        List[0] = GameObject.Find("Main Camera");
        List[1] = GetComponent<PlayerController>().cameraHolder.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        for ( int i = 0 ; i < ListSize ; i++ )
        {
            if ( i != ActiveCam )
            {
                List[i].GetComponent<Camera>().enabled = false;
            }
            else
            {
                List[i].GetComponent<Camera>().enabled = true;
            }
        }
    }
}
