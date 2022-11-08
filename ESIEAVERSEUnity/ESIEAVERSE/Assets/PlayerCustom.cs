using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustom : MonoBehaviour
{
    [SerializeField] GameObject[] Player;
    int s;
    public static int nj;
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        if (nj == -1)
        {
            s = Random.Range(0, 18);
            Player[s].SetActive(true);
        }
        else
        {
            Player[nj].SetActive(true);
        }
    }

    public void Droite()
    {
        Player[s].SetActive(false);
        s += 1;
        if(s == 18)
        {
            s = 0;
        }
        Player[s].SetActive(true);
    }
    public void Gauche()
    {
        Player[s].SetActive(false);
        s -= 1;
        if(s == -1)
        {
            s = 17;
        }
        Player[s].SetActive(true);
    }
    public void V()
    {
        nj = s;
        anim.SetTrigger("v");

    }
}
