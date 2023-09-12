using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    public bool canPause;
    private bool isPaused;
    public PanelsManager panelsManager;

    private void OnEnable()
    {
        InputSystem.OnPause += Pause;
    }
    private void OnDisable()
    {
        InputSystem.OnPause -= Pause;
    }
    void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            GameManager.instance.SwitchState("Pause");
            panelsManager.SwitchPanel("Pause");
        }

        else
        {
            isPaused = false;
            GameManager.instance.SwitchState("Gameplay");
            panelsManager.SwitchPanel("Gameplay");
        }
    }
}