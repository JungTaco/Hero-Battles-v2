using UnityEngine;

public class ShieldButton : BattleMenuButton
{
	public void Shield()
	{
		ChangePlayerState();
		battleHandler.ShieldSelf();
	}

	public override string GetTooltipHeader()
	{
		return "Shield";
	}

	public override string GetTooltipContent()
	{
		return "Shield for 1 turn";
	}
}
