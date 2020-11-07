using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameStateManager gameStateManager;
    public GameObject dialogView;
    public Button[] buttons;


    void Update()
    {
        switch (GamePhase.WaitingForSelection)
        {
            case GamePhase.WaitingForSelection:
                dialogView.SetActive(true);
                UpdateSelection();
                break;
            case GamePhase.ExecutingAction:
            case GamePhase.CalculatingActions:
                dialogView.SetActive(false);
                break;
            default:
        }
    }

    private void UpdateSelection()
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
            var action = actions[i];
            var text = button.GetComponentInChildren<Text>();
            text.text = action.Description();
            button.onClick.AddListener(() =>
            {
                gameStateManager.RunAction(action);
            });
        }
    }
}
