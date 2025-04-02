using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	private string header;
	private string content;
	private BattleMenuButton button;

	private void Start()
	{
		button = GetComponent<BattleMenuButton>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		SetText();
		TooltipSystem.Show(content, header);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		TooltipSystem.Hide();
	}

	private void SetText()
	{
		if (header == null)
			header = button.GetTooltipHeader();
		if (content == null)
			content = button.GetTooltipContent();
	}
}
