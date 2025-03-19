using System;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenuButton : MonoBehaviour
{
    protected Button Button;

    private void Awake()
    {
        Button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        Actions.OnStateChanged += ChangeButtonState;
    }

    private void OnDisable()
    {
        Actions.OnStateChanged -= ChangeButtonState;
    }

    private void Enable()
    {
        Button.interactable = true;
    }

    private void Disable()
    {
        Button.interactable = false;
    }

    private void ChangeButtonState(BattleHandler.State newState)
    {
        if (newState == BattleHandler.State.WaitingForPlayer)
        {
            Enable();
        }
        else
        {
            Disable();
        }
    }
}
