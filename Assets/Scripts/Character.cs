using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private AnimationClip idleAnimation;
	[SerializeField] 
	private AnimationClip slideAnimation;
	[SerializeField]
	private AnimationClip attackAnimation;
    private Animator anim;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {	
	    anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void PlaySlideAnimation()
	{
		
	}

	public void PlayAttackAnimation()
	{
		anim.SetTrigger("TrAttack");
	}
}
