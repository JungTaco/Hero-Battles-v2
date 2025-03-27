using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HeroButton : MonoBehaviour
{
    public Transform ButtonCharacter;
    private UnityEngine.UI.Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(ChangeScene);
	}

    private void ChangeScene()
    {
        GlobalVariables.chosenHero = ButtonCharacter;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
