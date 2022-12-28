using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject go;
    public bool Activated;

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, ( 5 * transform.TransformDirection(Vector3.forward)) , Color.green);
        if ( Physics.Raycast( transform.position , ( 5 * transform.TransformDirection(Vector3.forward) ) , out hit , 15))
        {
            if ( hit.transform.gameObject.tag == "Interaction")
            {
                go = hit.transform.gameObject;
                go.GetComponent<Outline>().enabled = true;
            }
            else
            {
                if ( go )
                {
                    go.GetComponent<Outline>().enabled = false;
                    go = null;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key was pressed.");
            Activated = true;
            go.GetComponent<AnimInteract>().Open = !go.GetComponent<AnimInteract>().Open;
        }
        
        if ( Input.GetKeyUp(KeyCode.F) )
        {
            Debug.Log("F key was released.");
            Activated = false;
        }
        
        /*
        if (Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("F key was released.");
            Activated = false;
            go.GetComponent<AnimInteract>().Open = false;
        }
        */


        /*
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Activated = true;
        }
        else
        {
            Activated = false;
        }
        */
    }
}
