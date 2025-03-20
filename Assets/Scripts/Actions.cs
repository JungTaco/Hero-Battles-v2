using System;
using UnityEngine;

public static class Actions
{
    public static Action<BattleHandler.PlayerState> OnStateChanged;
    public static Action OnAttackFinished;
}
