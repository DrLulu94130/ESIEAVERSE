using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] Menu[] menus;
    [SerializeField] AudioClip[] clips;

    void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                menus[i].Open();
            }
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }
    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
        if (menu.menuName != "title")
        {
            SoundManager.Instance.PlaySound(clips[1]);
        }
        SoundManager.Instance.PlaySound(clips[0]);

    }
    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }

    public void PlaySound()
    {
        int i = Random.Range(0, 4);
        SoundManager.Instance.PlaySound(clips[i]);
    }

}
