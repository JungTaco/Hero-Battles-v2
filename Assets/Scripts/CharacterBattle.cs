using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }
    
    private void Update()
    {

    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
    
    public void Attack()
    {
        // Vector3 attackDirection = (target.GetPosition() - GetPosition()).normalized;
        // character.PlayAttackAnimation(attackDirection, null, () =>
        // {
        //     //character.PlayIdleAnimation();
        // });
        character.PlayAttackAnimation();
    }
}
