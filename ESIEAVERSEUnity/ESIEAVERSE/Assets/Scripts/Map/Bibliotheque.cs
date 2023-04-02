/*This script display and hide the menu needed for the library. For more info see OpenLink.cs*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bibliotheque : MonoBehaviour
{
    public static bool isOn = false;

    public GameObject BibliothequeUI;
    // Start is called before the first frame update
    void Start()
    {
        BibliothequeUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isOn)
        {
            BibliothequeUI.SetActive(true);
        }
        else
        {
            BibliothequeUI.SetActive(false);
        }
    }
}
