using UnityEngine;
using UnityEngine.UI;

public class BattleMenuButton : MonoBehaviour
{
    protected Button Button;
    private BattleHandler battleHandler;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button = GetComponent<Button>();
        battleHandler = BattleHandler.GetInstance();
        // something
    }

    private void Enable()
    {
        Button.interactable = true;
    }

    private void Disable()
    {
        Button.interactable = false;
    }

    private void ChangeButtonState()
    {
        if (battleHandler.GetState() == BattleHandler.State.WaitingForPlayer)
        {
            Enable();
        }
        else
        {
            Disable();
        }
    }
}
