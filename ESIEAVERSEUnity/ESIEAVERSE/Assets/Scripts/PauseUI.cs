using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Pause.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && (!(Tableau.isOn)))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Pause.isOn = pauseMenu.activeSelf;
    }

    public void OffPauseMenu()
    {
        pauseMenu.SetActive(false);
        Pause.isOn = false;
    }

    public void OnPauseMenu()
    {
        pauseMenu.SetActive(true);
        Pause.isOn = true;
    }
}
