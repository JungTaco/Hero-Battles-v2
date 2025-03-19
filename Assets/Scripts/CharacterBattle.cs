using System;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private Character character;
    private bool isSliding;
    private Vector3 slideTargetPosition;
    
    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        isSliding = false;
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
                //onSlideComplete?
            }
        }
    }

    private Vector3 GetPosition()
    {
        return transform.position;
    }
    
    public void Attack()
    {
        character.PlayAttackAnimation();
        Actions.OnAttackFinished(character.GetIsPlayer());
    }
}
