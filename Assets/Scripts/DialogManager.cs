using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameStateManager gameStateManager;
    public GameObject dialogView;
    private Button[] buttons;


    void Start()
    {
        buttons = dialogView.GetComponentsInChildren<Button>();
        dialogView.SetActive(false);
    }

    void Update()
    {
        switch (GamePhase.WaitingForSelection)
        {
            case GamePhase.WaitingForSelection:
                dialogView.SetActive(true);
                UpdateSelection();
                break;
            default:
                dialogView.SetActive(false);
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
