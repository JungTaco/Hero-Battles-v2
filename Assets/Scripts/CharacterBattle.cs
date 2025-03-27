using System;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private Character character;
    private bool isSliding;
	private Vector3 slideTargetPosition;
    private Action onSlideComplete;
    private HealthSystem healthSystem;
    private HPBar hpBar;
    private struct DamageAmounts
    {
        private int attackDamage;
        private int spellDamage;

        public DamageAmounts(int attackDamage, int spellDamage)
        {
            this.attackDamage = attackDamage;
            this.spellDamage = spellDamage;
        }

        public int GetAttackDamage()
        {
            return attackDamage;
        }

        public int GetSpellDamage()
        {
            return spellDamage;
        }
	}
    private DamageAmounts damageAmounts;

	private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        isSliding = false;
		healthSystem = new HealthSystem(100);
        //TO DO: set depending on what level and what class character is
		damageAmounts = new DamageAmounts(10, 5);
		hpBar = GetComponentInChildren<Canvas>().GetComponentInChildren<HPBar>();
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

    public void GetsDamaged(int damage)
    {
        healthSystem.GetsDamage(damage);
        hpBar.UpdateSliderValue(healthSystem.GetHealthPercent());
    }

    public bool IsDead()
    {
        return healthSystem.IsDead();
    }

	public void Attack(CharacterBattle target)
    {
        Vector3 targetPosition = target.GetPosition() + (GetPosition() - target.GetPosition()).normalized;
        Vector3 startPosition = GetPosition();
        
        //slide to taget
        SetSlideValues(targetPosition, () =>
        {
            //arrived to target: stop sliding and attack
            isSliding = false;
            character.PlayAttackAnimation();
            target.GetsDamaged(damageAmounts.GetAttackDamage());
			//set target to original position
			slideTargetPosition = startPosition;
		});
	}

    public void HideHPBar() 
    { 
        hpBar.gameObject.SetActive(false);
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
    private void SlideToOriginalPosition(CharacterBattle characterBattle)
    {
		if (ReferenceEquals(this, characterBattle))
		{
			SetSlideValues(slideTargetPosition, () =>
			{
				isSliding = false;
                FinishTurn();
			});
		}
    }

    private void FinishTurn()
    {
        onSlideComplete = null;
		Actions.OnTurnFinished?.Invoke();
    }
}
