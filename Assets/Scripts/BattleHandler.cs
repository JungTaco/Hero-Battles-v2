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
	private Action onStateChanged;
	private State state;
	
	public enum State
	{
		WaitingForPlayer,
		Busy,
	}

	public State GetState()
	{
		return state;
	}

	public CharacterBattle GetPlayer()
	{
		return playerCharacterBattle;
	}
	
	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		playerCharacterBattle = SpawnHero();
		enemyCharacterBattle = SpawnEnemy();
		ChangeState(State.WaitingForPlayer);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			playerCharacterBattle.Attack();
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

	private void ChangeState(State newState)
	{
		state = newState;
		onStateChanged();
	}
}
