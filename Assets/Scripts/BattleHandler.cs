using UnityEngine;

public class BattleHandler : MonoBehaviour
{
	//will be chosen by the player
	[SerializeField]
    private Transform prefabHero;
	[SerializeField]
	private Transform prefabEnemy;

	private void Start()
	{
		SpawnHero();
		SpawnEnemy();
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space)) 
		{ 
			//test animation
		}
	}

	private void SpawnHero()
	{
		Vector3 position = new Vector3(-2.5f, 0);
		Instantiate(prefabHero, position, Quaternion.identity);
	}

	private void SpawnEnemy()
	{
		Vector3 position = new Vector3(2.5f, 0);
		Instantiate(prefabEnemy, position, Quaternion.identity);
	}
}
