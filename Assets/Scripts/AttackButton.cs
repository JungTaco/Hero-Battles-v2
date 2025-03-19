using System;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : BattleMenuButton
{
    private CharacterBattle playerCharacterBattle;
    //private CharacterBattle targetCharacterBattle;
    private BattleHandler battleHandler;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        battleHandler = BattleHandler.GetInstance();
        playerCharacterBattle = battleHandler.GetPlayer();
        //targetCharacterBattle = battleHandler.GetEnemy();
        Button = GetComponent<Button>();
        
        //Button.onClick.AddListener(playerCharacterBattle.Attack);
        Button.onClick.AddListener(battleHandler.PlayerAttack);
    }
}
