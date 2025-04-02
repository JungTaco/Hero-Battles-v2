using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
	[SerializeField]
	private PopUpText PrefabPopUpText;
	[SerializeField]
	private Transform popUpTextPos;
    [SerializeField]
    private Canvas canvas;
	private Character character;
    private bool isSliding;
	private Vector3 slideTargetPosition;
    private Action onSlideComplete;
    private HealthSystem healthSystem;
    private MagicSystem magicSystem;
    private HPBar hpBar;
	private MPBar mpBar;
	private bool isShielded;
    private AudioSource audioSource;
    private BattleStats battleStats;

    public BattleStats GetBattleStats()
    {
        return battleStats;
    }

	private void Awake()
    {
        character = GetComponent<Character>();
		battleStats = new BattleStats(10, 5, 15, 10);
	}

    private void Start()
    {
		isSliding = false;
		healthSystem = new HealthSystem(100);
		magicSystem = new MagicSystem(100);
		//TO DO: set depending on what level and what class character is
		
		hpBar = GetComponentInChildren<Canvas>().GetComponentInChildren<HPBar>();
		mpBar = GetComponentInChildren<Canvas>().GetComponentInChildren<MPBar>();
		isShielded = false;
        audioSource = GetComponentInChildren<AudioSource>();
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
        Actions.OnSpellAttackFinished += FinishTurn;
	}

	private void OnDisable()
	{
		Actions.OnAttackFinished -= SlideToOriginalPosition;
		Actions.OnSpellAttackFinished -= FinishTurn;
	}

    public void GetsDamaged(int damage)
    {
		int damageReceived;
        if (isShielded)
        {
            damageReceived = 0;
		}
        else 
        { 
            damageReceived = damage; 
        }
        healthSystem.GetsDamage(damageReceived);
        hpBar.UpdateSliderValue(healthSystem.GetHealthPercent());
		PopUpText popUpText = PrefabPopUpText.Create(popUpTextPos.position, damageReceived, false);
		popUpText.GetComponent<RectTransform>().SetParent(canvas.transform);
        isShielded = false;
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
            audioSource.Play();
            target.GetsDamaged(battleStats.GetAttackDamage());
			//set target to original position
			slideTargetPosition = startPosition;
		});
	}

	public void SpellAttack(CharacterBattle target)
    {
        character.PlaySpellAttackAnimation();
		target.GetsDamaged(battleStats.GetSpellDamage());
        magicSystem.GetsUsed(battleStats.GetHealingAmount());
		mpBar.UpdateSliderValue(magicSystem.GetMpPercent());
	}

	public void HideBars() 
    { 
        hpBar.gameObject.SetActive(false);
		mpBar.gameObject.SetActive(false);
	}

    public void ShieldSelf()
    {
        isShielded = true;
        FinishTurn(this);
    }

    public void Heal()
    {
        healthSystem.Heal(battleStats.GetHealingAmount());
		//popup text - rename and change color in script
		PopUpText popUpText = PrefabPopUpText.Create(popUpTextPos.position, battleStats.GetHealingAmount(), true);
		popUpText.GetComponent<RectTransform>().SetParent(canvas.transform);
		FinishTurn(this);
	}

    public bool HasEnoughMp()
    {
        if (magicSystem.GetMpAmount() >= battleStats.GetSpellMpCost())
            return true;
        return false;
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
                FinishTurn(characterBattle);
			});
		}
    }

    private void FinishTurn(CharacterBattle characterBattle)
    {
		if (ReferenceEquals(this, characterBattle))
        {
			Actions.OnTurnFinished?.Invoke();
		}		
    }
}
