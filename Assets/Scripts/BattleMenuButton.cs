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

	protected void Start()
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

	public void ChangePlayerState()
	{
		battleHandler.ChangePlayerState(BattleHandler.PlayerState.TakingAction);
	}

	protected void Enable()
    {
        Button.interactable = true;
    }

	protected void Disable()
    {
        Button.interactable = false;
    }

    protected void ChangeButtonState(BattleHandler.PlayerState newState)
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
}
