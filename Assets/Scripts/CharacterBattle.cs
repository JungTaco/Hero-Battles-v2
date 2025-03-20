using System;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private Character character;
    private bool isSliding;
    private Vector3 startPosition;
    private Vector3 slideTargetPosition;
    private Action onSlideComplete;
    
    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        isSliding = false;
		startPosition = GetPosition();

	}

    private void Update()
    {
        float slideSpeed = 10f;
        if (isSliding)
        {
            transform.position += (slideTargetPosition - GetPosition()) * (slideSpeed * Time.deltaTime);

            if (Vector3.Distance(GetPosition(), slideTargetPosition) < 1f)
            {
                transform.position = slideTargetPosition;
                onSlideComplete?.Invoke();
            }
        }
    }

	private void OnEnable()
	{
		
	}

	private void OnDisable()
	{
		
	}

	public void Attack(CharacterBattle target)
    {
        Vector3 targetPosition = target.GetPosition() + (GetPosition() - target.GetPosition()).normalized;
        Vector3 startPosition = GetPosition();
        
        //slide to taget
        SlideToPosition(targetPosition, () =>
        {
            //arrived to target
            isSliding = false;
            character.PlayAttackAnimation();
            
            //animation event?

            //slide to original position
            //SlideToPosition(startPosition, () =>
            //{
            //    //isSliding = true;
            //    Actions.OnAttackFinished(character.GetIsPlayer());
            //    isSliding = false;
            //});
        });
        
    }
    
    private Vector3 GetPosition()
    {
        return transform.position;
    }

    private void SlideToPosition(Vector3 slideTargetPosition, Action onSlideComplete)
    {
        this.slideTargetPosition = slideTargetPosition;
        this.onSlideComplete = onSlideComplete;
        isSliding = true;
    }
    
    
}
