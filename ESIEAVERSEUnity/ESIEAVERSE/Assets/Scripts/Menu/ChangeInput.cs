using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInput : MonoBehaviour
{
    public InputField next;
    public InputField previous;


    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            if (previous)
            {
                previous.Select();
            }
        }
        else if ( Input.GetKeyDown(KeyCode.Tab))
        {
            if (next)
            {
                next.Select();
            }
        }
    }
}
