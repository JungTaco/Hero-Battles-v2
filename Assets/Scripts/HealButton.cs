using UnityEngine;

public class HealButton : BattleMenuButton
{
	public void Heal()
	{
		ChangePlayerState();
		battleHandler.Heal();
	}
}
