using System;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
	private static BattleHandler instance;

	public static BattleHandler GetInstance()
	{
		return instance;
	}
	
	//will be chosen by the player
	[SerializeField]
    private Transform prefabHero;
	[SerializeField]
	private Transform prefabEnemy;
	private CharacterBattle playerCharacterBattle;
	private CharacterBattle enemyCharacterBattle;
	
	private PlayerState state;
	
	public enum PlayerState
	{
		Ready,
		Waiting,
	}

	public PlayerState GetState()
	{
		return state;
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
		playerCharacterBattle = SpawnHero();
		enemyCharacterBattle = SpawnEnemy();
		//ChangeState(State.WaitingForPlayer);
		state = PlayerState.Ready;
	}

	private void Update()
	{

	}

	private void OnEnable()
	{
		//Actions.OnAttackFinished += ChangeState;
	}

	private void OnDisable()
	{
		//Actions.OnAttackFinished -= ChangeState;
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

	public void ChangeState(PlayerState newState)
	{
		state = newState;
		Actions.OnStateChanged?.Invoke(newState);
	}
	
	public void Attack()
	{
		if (state == PlayerState.Ready)
		{
			playerCharacterBattle.Attack(enemyCharacterBattle);
			//ChangeState(PlayerState.Waiting);
		}
		else 
		{
			enemyCharacterBattle.Attack(playerCharacterBattle);
			//ChangeState(PlayerState.Ready);
		}
	}
}
