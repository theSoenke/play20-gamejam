using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    //public GameStateManager gameStateManager;
    public GameObject dialogView;
    private Button[] buttons;   

    void Start()
    {

        GameStateManager.Instance.GamePhaseChanged += OnGamePhaseChanged;
        buttons = dialogView.GetComponentsInChildren<Button>();
        dialogView.SetActive(false);
    }

    private void OnGamePhaseChanged(GamePhase phase)
    {
        if(phase == GamePhase.WaitingForSelection)
        {            
            UpdateSelection();
            dialogView.SetActive(true);
        } 
        else
        {
            dialogView.SetActive(false);
        }
    }

    private void UpdateSelection()
    {
        var actions = GameStateManager.Instance.ActionsForSelection;
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
            text.text = action.Description(GameStateManager.Instance.State); // + "(" + action.EvaluateProbability(GameStateManager.Instance.State) +")";
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                GameStateManager.Instance.SelectAction(action);
            });
        }
    }
}
