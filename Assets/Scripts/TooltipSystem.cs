using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem instance;
	private Tooltip tooltip;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		tooltip = GetComponentInChildren<Tooltip>();
		Hide();
	}

	public static void Show(string content, string header = "")
	{
		instance.tooltip.SetText(content, header);
		instance.tooltip.gameObject.SetActive(true);
	}

	public static void Hide()
	{
		instance.tooltip.gameObject.SetActive(false);
	}
}
