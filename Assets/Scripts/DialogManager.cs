using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameStateManager gameStateManager;
    public Button[] buttons;

    void Start()
    {
        var actions = gameStateManager.Actions;

        if (actions.Length < buttons.Length)
        {
            Debug.LogError("Gimme some actions");
            return;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            var button = buttons[i];
            var text = button.GetComponentInChildren<Text>();
            text.text = actions[i].Description();
        }
    }
}
