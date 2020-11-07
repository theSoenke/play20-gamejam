using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

class ActionWithCachedPropability
{
    public ActionDescription Action {get; protected set;}
    public int ActionPropability {get; protected set;}
}

public enum GamePhase 
{
    CalculatingActions,
    WaitingForSelection,
    ExecutingAction,
    PhaseComplete
}

public class GameStateManager : MonoBehaviour
{
    public GameState State;

    public ActionDescription[] Actions;

    public GamePhase Phase {get; protected set;} = GamePhase.CalculatingActions;

    public void Awake() 
    {
        Actions = GetComponentsInChildren<ActionDescription>();
    }

    public void UpdateGame()
    {
        var actions = SelectActionsViaProbability(State);
        // Display actions
        foreach (var item in actions)
        {
            //DrawText(item.GetDescription());
            //IsClicked? -> SelectedAction
        }

        // SelectedAction.Execute(State);
        // SelectedAction.Animation.RunAnimation(State);
        // WaitFor(() => SelectedAction.Animation.IsRunning == false);
        // Run UpdateGame() next frame;
    }

    public IEnumerable<ActionDescription> SelectActionsViaProbability(GameState state)
    {
        return Actions.Take(4).ToArray();
    }
}
