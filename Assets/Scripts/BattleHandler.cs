using System;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
	private static BattleHandler instance;

	public static BattleHandler GetInstance()
	{
		return instance;
	}
	
	[SerializeField]
	private Transform prefabEnemy;
	private Transform prefabHero;
	private CharacterBattle playerCharacterBattle;
	private CharacterBattle enemyCharacterBattle;
	
	private PlayerState playerState;
	
	public enum PlayerState
	{
		Ready,
		TakingAction,
		Waiting,
	}

	public PlayerState GetState()
	{
		return playerState;
	}

	public CharacterBattle GetPlayer()
	{
		return playerCharacterBattle;
	}

	public CharacterBattle GetEnemy()
	{
		return enemyCharacterBattle;
	}
	
	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		prefabHero = GlobalVariables.chosenHero;
		GlobalVariables.ClearChosenHero();
		playerCharacterBattle = SpawnHero();
		enemyCharacterBattle = SpawnEnemy();
		playerState = PlayerState.Ready;
	}

	private void Update()
	{

	}

	private void OnEnable()
	{
		Actions.OnTurnFinished += DecideNextTurn;
	}

	private void OnDisable()
	{
		Actions.OnTurnFinished -= DecideNextTurn;
	}

	public void ChangePlayerState(PlayerState newState)
	{
		playerState = newState;
		Actions.OnStateChanged?.Invoke(newState);
	}

	public void Attack()
	{
		if (playerState == PlayerState.TakingAction)
		{

			playerCharacterBattle.Attack(enemyCharacterBattle);
		}
		else
		{
			enemyCharacterBattle.Attack(playerCharacterBattle);
		}
	}

	public void SpellAttack()
	{
		
		if (playerState == PlayerState.TakingAction)
		{
			playerCharacterBattle.SpellAttack(enemyCharacterBattle);
		}
		else
		{
			enemyCharacterBattle.SpellAttack(playerCharacterBattle);
		}
	}

	public void ShieldSelf()
	{
		if (playerState == PlayerState.TakingAction)
		{
			playerCharacterBattle.ShieldSelf();
		}
		else
		{
			enemyCharacterBattle.ShieldSelf();
		}
	}

	public void Heal()
	{
		if (playerState == PlayerState.TakingAction)
		{
			playerCharacterBattle.Heal();
		}
		else
		{
			enemyCharacterBattle.Heal();
		}
	}

	private CharacterBattle SpawnHero()
	{
		Vector3 position = new Vector3(-2.5f, 0);
		Transform characterTransform = Instantiate(prefabHero, position, Quaternion.identity);
		return characterTransform.GetComponent<CharacterBattle>();
	}

	private CharacterBattle SpawnEnemy()
	{
		Vector3 position = new Vector3(2.5f, 0);
		Transform characterTransform = Instantiate(prefabEnemy, position, Quaternion.identity);
		return characterTransform.GetComponent<CharacterBattle>();
	}

	private void DecideNextTurn()
	{
		if (IsBattleOver())
		{
			playerCharacterBattle.HideHPBar();
			enemyCharacterBattle.HideHPBar();
			return;
		}
		if (playerState == PlayerState.TakingAction)
		{
			ChangePlayerState(PlayerState.Waiting);
			DoEnemyAction();
		}
		else if (playerState == PlayerState.Waiting) 
		{
			ChangePlayerState(PlayerState.Ready);
		}
	}

	//choses an action for the enemy to do
	private void DoEnemyAction()
	{
		Attack();
	}

	private bool IsBattleOver()
	{
		if (playerCharacterBattle.IsDead())
		{
			BattleOverPanel.Show_Static("Enemy won!");
			return true;
		}
		if (enemyCharacterBattle.IsDead()) 
		{
			BattleOverPanel.Show_Static("You won!");
			return true;
		}
		return false;
	}
}
