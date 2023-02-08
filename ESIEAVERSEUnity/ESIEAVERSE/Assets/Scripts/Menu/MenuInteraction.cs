using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using static UnityEngine.Random;
public class MenuInteraction : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{
    public Menu3DModel GetN;
    [SerializeField] Animator anim;
    [SerializeField] int PlayerValue;
    [SerializeField] GameObject[] Player;
    private void Start()
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayerValue = GetN.n;
        for ( int i = 0 ; i < 20 ; i++ )
        {
            if ( PlayerValue == i )
            {
                Player[i].GetComponent<Outline>().enabled = true;
            }
            else
            {
                Player[i].GetComponent<Outline>().enabled = false;
            }
        }
        float randomNumber = Range(0, 10);
        if (randomNumber == 0)
        {
            anim.Play("1");
        }
        if (randomNumber == 1)
        {
            anim.Play("1 0");
        }
        if (randomNumber == 2)
        {
            anim.Play("1 1");
        }
        if (randomNumber == 3)
        {
            anim.Play("1 2");
        }
        if (randomNumber == 4)
        {
            anim.Play("1 3");
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
    }
}