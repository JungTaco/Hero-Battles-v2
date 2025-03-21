using System;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private Character character;
    private bool isSliding;
	private bool isActiveCharacter;
	private Vector3 slideTargetPosition;
    private Action onSlideComplete;

	private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        isSliding = false;
        isActiveCharacter = false;
	}

    private void Update()
    {
        if (isSliding)
        {
            Slide();
        }
    }

	private void OnEnable()
	{
        Actions.OnAttackFinished += SlideToOriginalPosition;
	}

	private void OnDisable()
	{
		Actions.OnAttackFinished -= SlideToOriginalPosition;
	}

	public void Attack(CharacterBattle target)
    {
        isActiveCharacter = true;
        Vector3 targetPosition = target.GetPosition() + (GetPosition() - target.GetPosition()).normalized;
        Vector3 startPosition = GetPosition();
        
        //slide to taget
        SetSlideValues(targetPosition, () =>
        {
            //arrived to target: stop sliding and attack
            isSliding = false;
            character.PlayAttackAnimation();

			//set target to original position
			slideTargetPosition = startPosition;
		});
        
    }
    
    private void Slide()
    {
		float slideSpeed = 10f;
		transform.position += (slideTargetPosition - GetPosition()) * (slideSpeed * Time.deltaTime);

		if (Vector3.Distance(GetPosition(), slideTargetPosition) < 1f)
		{
			transform.position = slideTargetPosition;
			onSlideComplete?.Invoke();
		}
	}

    private Vector3 GetPosition()
    {
        return transform.position;
    }

    private void SetSlideValues(Vector3 slideTargetPosition, Action onSlideComplete)
    {
        this.slideTargetPosition = slideTargetPosition;
        this.onSlideComplete = onSlideComplete;
        isSliding = true;
	}

    //when attack animation is finished slides back to original position
    private void SlideToOriginalPosition()
    {
		if (isActiveCharacter)
		{
			SetSlideValues(slideTargetPosition, () =>
			{
				isSliding = false;
                isActiveCharacter = false;
			});
		}
    }
}
