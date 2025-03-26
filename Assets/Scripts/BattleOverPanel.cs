using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleOverPanel : MonoBehaviour
{
	private static BattleOverPanel instance;

	private void Awake()
	{
		instance = this;
		Hide();
	}

	private void Hide()
	{
		gameObject.SetActive(false);
	}

	private void Show(string winnerString)
	{
		gameObject.SetActive(true);

		transform.Find("WinnerText").GetComponent<TMP_Text>().text = winnerString;
	}

	public static void Show_Static(string winnerString)
	{
		instance.Show(winnerString);
	}
}