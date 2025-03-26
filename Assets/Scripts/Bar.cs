using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    private Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		slider = GetComponent<Slider>();
	}

    public void UpdateSliderValue(float percent)
    {
        slider.value = percent;
	}
}
