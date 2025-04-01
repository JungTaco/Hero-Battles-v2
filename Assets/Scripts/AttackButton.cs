using UnityEngine;

public class AttackButton : BattleMenuButton
{
    public void Attack()
    {
		ChangePlayerState();
		battleHandler.Attack();
	}
}
