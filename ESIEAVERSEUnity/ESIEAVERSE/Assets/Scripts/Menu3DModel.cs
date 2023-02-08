using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu3DModel : MonoBehaviour
{
    public int n;
    [SerializeField] GameObject[] Player;
    [SerializeField] Animator anim;
    void Update()
    {
        n = PlayerCustom.nj;
        if (n != -1)
        {
            Player[n].SetActive(true);
        }
        else
        {
            Player[10].SetActive(true);
        }
    }
    public void LeaveModel()
    {
        n = PlayerCustom.nj;
        if (n != -1)
        {
            Player[n].SetActive(false);
        }
        else
        {
            Player[10].SetActive(false);
        }
    }
}
