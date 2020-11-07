using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

class ActionWithCachedPropability
{
    public ActionDescription Action { get; set; }
    public int ActionProbability { get; set; }
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

    public GamePhase Phase { get; protected set; } = GamePhase.CalculatingActions;


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

    public void RunAction(ActionDescription action)
    {
        action.Execute(State);
    }

    public IEnumerable<ActionDescription> SelectActionsViaProbability(GameState state)
    {
        var cachedActionList = new List<ActionWithCachedPropability>();
        var totalProbability = 0;
        foreach (var action in Actions)
        {
            var probability = action.EvaluateProbability(state);
            totalProbability += probability;
            var cachedAction = new ActionWithCachedPropability { Action = action, ActionProbability = probability };
            cachedActionList.Add(cachedAction);
        }
        var result = new List<ActionDescription>();
        for (var _ = 0; _ <= 4; _++)
        {
            var rng = Random.Range(0, totalProbability);
            var probabilityOffset = 0;
            foreach(var action in cachedActionList) {
                probabilityOffset += action.ActionProbability;
                if(rng < probabilityOffset && rng >= (probabilityOffset - action.ActionProbability)) {
                    result.Add(action.Action);
                    break;
                }
            }
        }
        return result;
    }
}
