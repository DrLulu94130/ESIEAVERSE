using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateModel : MonoBehaviour
{
    [SerializeField] GameObject[] Player;
    // Start is called before the first frame update
    void Start()
    {
       /* if (PlayerCustom.nj != -1)
        {
            Player[PlayerCustom.nj].SetActive(true);
        }
        else
        { */
            int s = Random.Range(0, 18);
            Player[s].SetActive(true);
       // }
    }
}
