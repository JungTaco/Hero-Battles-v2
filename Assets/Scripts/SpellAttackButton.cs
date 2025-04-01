using UnityEngine;

public class SpellAttackButton : BattleMenuButton
{
	private void OnEnable()
	{
		Actions.OnMpChanged += CheckHasEnoughMp;
	}

	private void OnDisable()
	{
		Actions.OnMpChanged -= CheckHasEnoughMp;
	}

	private void CheckHasEnoughMp()
	{
		if (battleHandler.CurrentCharacterHasEnoughMp())
			Enable();
		else
			Disable();
	}
}
