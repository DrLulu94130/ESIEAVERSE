using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator anim;

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.Play("ScaleUp");
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        anim.Play("ScaleDown");
    }

    public void OnSelect(BaseEventData eventData)
    {
        anim.Play("ScaleDown");
    }
}
