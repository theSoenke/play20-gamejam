using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameState State;
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
        return Enumerable.Empty<ActionDescription>();
    }
}
