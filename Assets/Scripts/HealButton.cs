using UnityEngine;

public class HealButton : BattleMenuButton
{
	public void Heal()
	{
		ChangePlayerState();
		battleHandler.Heal();
	}

	public override string GetTooltipHeader()
	{
		return "Heal";
	}

	public override string GetTooltipContent()
	{
		return "Heal amount: " + battleHandler.GetPlayer().GetBattleStats().GetHealingAmount();
	}
}
