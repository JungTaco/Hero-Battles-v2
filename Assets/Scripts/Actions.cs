using System;
using UnityEngine;

public static class Actions
{
    public static Action<BattleHandler.PlayerState> OnStateChanged;
    public static Action<CharacterBattle> OnAttackFinished;
	public static Action<CharacterBattle> OnSpellAttackFinished;
	public static Action OnTurnFinished;
}
