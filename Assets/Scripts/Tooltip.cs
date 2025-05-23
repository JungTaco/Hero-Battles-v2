using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI headerField;
	[SerializeField]
	private TextMeshProUGUI contentField;
	[SerializeField]
	private int characterWrapLimit;
	private LayoutElement LayoutElement;
	private RectTransform rectTransform;

	private void Awake()
	{
		LayoutElement = GetComponent<LayoutElement>();
		rectTransform = GetComponent<RectTransform>();
	}

	public void SetText(string content, string header = "")
	{
		if (string.IsNullOrEmpty(header))
		{
			headerField.gameObject.SetActive(false);
		}
		else
		{
			headerField.gameObject.SetActive(true);
			headerField.text = header;
		}

		contentField.text = content;

		int headerLength = headerField.text.Length;
		int contentLength = contentField.text.Length;

		LayoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit);
	}

	private void Update()
	{
		Vector2 position = Input.mousePosition;
		float pivotX = position.x / Screen.width;
		float pivotY = position.y / Screen.height;
		rectTransform.pivot = new Vector2(pivotX, pivotY);
		transform.position = position;
	}
}
