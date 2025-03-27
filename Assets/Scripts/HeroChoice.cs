using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroChoice : MonoBehaviour
{
    [SerializeField]
    private List<Transform> characterList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform c in characterList)
        {
			CreateButton(c);
		}
    }

    private void CreateButton(Transform c)
    {
		Character character = c.GetComponent<Character>();
		GameObject button = TMP_DefaultControls.CreateButton(new TMP_DefaultControls.Resources());
		HeroButton heroButton = button.AddComponent<HeroButton>();
		heroButton.ButtonCharacter = c;
		Image image = button.GetComponent<Image>();
		image.sprite = character.GetPortrait();
		Destroy(button.GetComponentInChildren<TMP_Text>().gameObject);
		button.GetComponent<RectTransform>().SetParent(transform);
		Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
		button.transform.localPosition = pos;
		button.transform.localScale = Vector3.one;
	}
}
