using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Animation idleAnimation;
	[SerializeField]
    private Animation slideAnimation;
	[SerializeField]
    private Animation attackAnimation;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void PlaySlideAnimation()
	{
		slideAnimation.Play();
	}

	public void PlayAttackAnimation()
	{
		attackAnimation.Play();
	}
}
