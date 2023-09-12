using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static System.Action<string> OnStateChange;

    [SerializeField] private string initialState;
    private string actualState;
    
    void Start()
    {
        SwitchState(initialState);
    }

    public void SwitchState(string newState)
    {
        if (actualState == newState) return;
        actualState = newState;

        OnStateChange?.Invoke(newState);
    }
}
