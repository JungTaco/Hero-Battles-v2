using UnityEngine;

public class ShieldButton : BattleMenuButton
{
	public void Shield()
	{
		ChangePlayerState();
		battleHandler.ShieldSelf();
	}
}
