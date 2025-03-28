using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnimationEvent : MonoBehaviour
{
    private CharacterBattle characterBattle;

	private void Start()
	{
		characterBattle = transform.parent.GetComponent<CharacterBattle>();
	}

	public void FinishAttack()
    {
        Actions.OnAttackFinished?.Invoke(characterBattle);
    }

	public void FinishSpellAttack()
	{
		Actions.OnSpellAttackFinished?.Invoke();
	}
}
