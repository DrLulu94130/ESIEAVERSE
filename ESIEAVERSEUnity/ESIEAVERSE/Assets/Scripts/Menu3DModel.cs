using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu3DModel : MonoBehaviour
{
    [SerializeField] GameObject[] Player;
    [SerializeField] Animator anim;
    void Update()
    {
        int n = PlayerCustom.nj;
        if (n != -1)
        {
            Player[n].SetActive(true);
        }
        else
        {
            Player[10].SetActive(true);
        }
        anim.SetInteger("d", Random.Range(0, 4));
    }
    public void LeaveModel()
    {
        int n = PlayerCustom.nj;
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
