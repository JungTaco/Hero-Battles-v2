using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField]
	private bool isPlayer;
	[SerializeField]
	private Sprite portrait;
	private Animator anim;
    
    private static readonly int TrAttack = Animator.StringToHash("TrAttack");
    private static readonly int IsSliding = Animator.StringToHash("IsSliding");

    public bool GetIsPlayer()
    {
	    return isPlayer;
    }

	public Sprite GetPortrait()
	{
		return portrait;
	}
    
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {	
	    anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void PlayAttackAnimation()
	{
		anim.SetTrigger(TrAttack);
	}
	
	public void PlaySlideAnimation()
	{
		anim.SetBool(IsSliding, true);
	}
}
