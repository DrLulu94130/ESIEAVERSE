using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public bool isOn;

    Transform tf;
    public GameObject Target;

    private void Awake()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( isOn )
        {
            Target.SetActive(true);
        }
        else
        {
            Target.SetActive(false);
        }
    }
}
