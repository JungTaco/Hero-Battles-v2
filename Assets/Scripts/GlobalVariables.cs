using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
	public static Transform chosenHero;

	public static void ClearChosenHero()
	{
		chosenHero = null;
	}
}
