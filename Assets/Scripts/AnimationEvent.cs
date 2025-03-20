using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnimationEvent : MonoBehaviour
{
    public void FinishAttack()
    {
        Actions.OnAttackFinished?.Invoke();
    }
}
