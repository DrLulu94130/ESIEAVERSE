/*using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public RectTransform Button;
    [SerializeField] Animator anim;
    void Start()
    {
        anim.SetTrigger("Normal");
        anim.ResetTrigger("Highlighted");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.ResetTrigger("Normal");
        anim.SetTrigger("Highlighted");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetTrigger("Normal");
        anim.ResetTrigger("Highlighted");
    }
} */
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
