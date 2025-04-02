using UnityEngine;

public class AttackButton : BattleMenuButton
{
    public void Attack()
    {
		ChangePlayerState();
		battleHandler.Attack();
	}

	public override string GetTooltipHeader()
	{
		return "Melee Attack";
	}

	public override string GetTooltipContent()
	{
		return "Attack damage: " + battleHandler.GetPlayer().GetBattleStats().GetAttackDamage();
	}
}
