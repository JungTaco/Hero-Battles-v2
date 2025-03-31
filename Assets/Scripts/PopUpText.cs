using System;
using TMPro;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    [SerializeField]
    private Transform prefabPopUpText;
    private TMP_Text text;
	private float disappearTimer;
	private Color textColor;

	private void Awake()
    {
        text = GetComponent<TMP_Text>();
	}

	private void Update()
	{
		float moveSpeed = .5f;
		transform.position += new Vector3(0, moveSpeed*Time.deltaTime, 0);

		disappearTimer -= Time.deltaTime;
		if (disappearTimer < 0f)
		{
			float disappearSpeed = 3f;
			textColor.a -= disappearSpeed * Time.deltaTime;
			text.color = textColor;
			if (textColor.a < 0f) 
			{
				Destroy(gameObject);
			}
		}
	}

	public PopUpText Create(Vector3 position, int amount, bool isHealing)
	{
		Transform PopUpTransform = Instantiate(prefabPopUpText, position, Quaternion.identity);
		PopUpText PopUpText = PopUpTransform.GetComponent<PopUpText>();
		PopUpText.Setup(amount, isHealing);
		return PopUpText;
	}

	private void Setup(int amount, bool isHealing)
	{
		text.SetText(amount.ToString());
		disappearTimer = .5f;
		if (isHealing)
		{
			text.color = Color.green;
		}
		textColor = text.color;	
	}
}
