using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using static UnityEngine.Random;
public class MenuInteraction : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{
    [SerializeField] Animator anim;
    private void Start()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
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