using System;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : BattleMenuButton
{
    private CharacterBattle playerCharacterBattle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCharacterBattle = BattleHandler.GetInstance().GetPlayer();
        Button = GetComponent<Button>();
        Button.onClick.AddListener(playerCharacterBattle.Attack);
    }
}
