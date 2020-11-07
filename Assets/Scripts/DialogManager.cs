using System.Linq;
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

    //void Update()
    //{
    //    switch (gameStateManager.Phase)
    //    {
    //        case GamePhase.WaitingForSelection:
    //            dialogView.SetActive(true);
    //            UpdateSelection();
    //            break;
    //        default:
    //            dialogView.SetActive(false);
    //            break;
    //    }
    //}

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
            text.text = action.Description();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                GameStateManager.Instance.SelectAction(action);
            });
        }
    }
}
