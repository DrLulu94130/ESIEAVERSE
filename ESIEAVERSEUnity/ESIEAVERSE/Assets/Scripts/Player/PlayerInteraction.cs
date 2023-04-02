using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject go;
    public bool Activated;
    GameObject CanvaF;

    void Start()
    {
        CanvaF = GameObject.Find("FInteraction");
    }

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, ( 5 * transform.TransformDirection(Vector3.forward)) , Color.green); // Raycast Renderer in Unity
        if ( Physics.Raycast( transform.position , ( 5 * transform.TransformDirection(Vector3.forward) ) , out hit , 15))
        {
            if ( hit.transform.gameObject.tag == "Interaction")
            {
                CanvaF.SetActive(true);
                go = hit.transform.gameObject;
                go.GetComponent<Interaction>().Selected = true;
            }
            else
            {
                CanvaF.SetActive(false);
                if ( go )
                {
                    go.GetComponent<Interaction>().Selected = false;
                    go = null;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key was pressed.");
            Activated = true;
            go.GetComponent<Interaction>().Triggered = !go.GetComponent<Interaction>().Triggered;
        }
        
        if ( Input.GetKeyUp(KeyCode.F) )
        {
            Debug.Log("F key was released.");
            Activated = false;
        }
    }
}
