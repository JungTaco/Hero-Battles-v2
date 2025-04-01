using UnityEngine;

public class SpellAttackButton : BattleMenuButton
{
	private void Start()
	{
		base.Start();
		Actions.OnMpChanged += CheckHasEnoughMp;
	}

	//private void OnEnable()
	//{
	//	Actions.OnMpChanged += CheckHasEnoughMp;
	//}

	//private void OnDisable()
	//{
	//	Actions.OnMpChanged -= CheckHasEnoughMp;
	//}

	public void SpellAttack()
	{
		ChangePlayerState();
		battleHandler.SpellAttack();
	}

	private void CheckHasEnoughMp()
	{
		if (battleHandler.CurrentCharacterHasEnoughMp() && battleHandler.GetState() == BattleHandler.PlayerState.Waiting)
			Enable();
		else
			Disable();
	}
}
