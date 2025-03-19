using System;
using UnityEngine;

public static class Actions
{
    public static Action<BattleHandler.State> OnStateChanged;
    public static Action<bool> OnAttackFinished;
}
