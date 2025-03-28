using System;
using TMPro;
using UnityEngine;

public class DamagePopUpText : MonoBehaviour
{
    [SerializeField]
    private Transform prefabDamagePopUpText;
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

	public DamagePopUpText Create(Vector3 position, int damageAmount)
	{
		Transform damagePopUpTransform = Instantiate(prefabDamagePopUpText, position, Quaternion.identity);
		DamagePopUpText damagePopUpText = damagePopUpTransform.GetComponent<DamagePopUpText>();
		damagePopUpText.Setup(damageAmount);
		return damagePopUpText;
	}

	private void Setup(int damageAmount)
	{
		text.SetText(damageAmount.ToString());
		disappearTimer = .5f;
		textColor = text.color;
	}
}
