using UnityEngine;

public class SpellAttackButton : BattleMenuButton
{
	private void Start()
	{
		base.Start();
		Actions.OnMpChanged += CheckHasEnoughMp;
	}

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

	public override string GetTooltipHeader()
	{
		return "Spell attack";
	}

	public override string GetTooltipContent()
	{
		return "Spell attack damage: " + battleHandler.GetPlayer().GetBattleStats().GetSpellDamage();
	}
}
