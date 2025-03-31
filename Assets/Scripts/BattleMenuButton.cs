using System;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenuButton : MonoBehaviour
{
    protected Button Button;
	protected BattleHandler battleHandler;

	private void Awake()
    {
		Button = GetComponent<Button>();
	}

	private void Start()
	{
		battleHandler = BattleHandler.GetInstance();
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

    private void ChangeButtonState(BattleHandler.PlayerState newState)
    {
        if (newState == BattleHandler.PlayerState.Ready)
        {
            Enable();
        }
        else
        {
            Disable();
        }
    }

    public void ChangePlayerState()
    {
		battleHandler.ChangePlayerState(BattleHandler.PlayerState.TakingAction);
	}
}
