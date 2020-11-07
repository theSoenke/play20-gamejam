using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

class ActionWithCachedPropability
{
    public ActionDescription Action {get; protected set;}
    public int ActionPropability {get; protected set;}
}

public class GameStateManager : MonoBehaviour
{
    public GameState State;

    public ActionDescription[] Actions;

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
        var cachedActionList = new List<ActionWithCachedPropability>();
        return Enumerable.Empty<ActionDescription>();
    }
}
