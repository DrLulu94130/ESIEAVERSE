using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu3DModel : MonoBehaviour
{
    [SerializeField] GameObject[] Player;
    void Update()
    {
        int n = PlayerCustom.nj;
        if (n != -1)
        {
            Player[n].SetActive(true);
        }
    }
    public void LeaveModel()
    {
        int n = PlayerCustom.nj;
        if (n != -1)
        {
            Player[n].SetActive(false);
        }
    }
}
