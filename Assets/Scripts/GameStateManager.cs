using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

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
    AnimatingAction,
    PhaseComplete
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private GamePhase _phase;
    private ActionDescription _currentAction;

    [SerializeField]
    private ActionDescription[] Actions;

    public SceneField EndScene;

    public GameState State;
    public ActionDescription[] ActionsForSelection;
    public event Action<GamePhase> GamePhaseChanged;
    public GamePhase Phase 
    { 
        get => _phase; 
        protected set
        {
            if (_phase == value)
                return;
            _phase = value;
            GamePhaseChanged?.Invoke(_phase);
        }
    }


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Debug.LogError("GameStateManager already exists in Scene. Deleting...");
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        Actions = GetComponentsInChildren<ActionDescription>();
        Phase = GamePhase.CalculatingActions;
    }

    private void Update()
    {
        switch (Phase)
        {
            case GamePhase.CalculatingActions:
                ActionsForSelection = SelectActionsViaProbability(State).ToArray();
                Phase = GamePhase.WaitingForSelection;
                break;           
            case GamePhase.AnimatingAction:
                if (_currentAction.Animation == null || !_currentAction.Animation.IsRunning)
                {
                    _currentAction = null;
                    Phase = GamePhase.PhaseComplete;
                }
                break;
            case GamePhase.PhaseComplete:
                Phase = GamePhase.CalculatingActions;
                break;
        }
    }

    public void SelectAction(ActionDescription action)
    {
        if(Phase != GamePhase.WaitingForSelection)
        {
            Debug.LogError("Try selecting action while not in waiting phase..");
            return;
        }

        _currentAction = action;
        Phase = GamePhase.ExecutingAction;

        _currentAction.Execute(State);

        Phase = GamePhase.AnimatingAction;
        _currentAction.Animation?.RunAnimation(State);
    }

    //public void UpdateGame()
    //{
    //    var actions = SelectActionsViaProbability(State);
    //    // Display actions
    //    foreach (var item in actions)
    //    {
    //        //DrawText(item.GetDescription());
    //        //IsClicked? -> SelectedAction
    //    }

    //    // SelectedAction.Execute(State);
    //    // SelectedAction.Animation.RunAnimation(State);
    //    // WaitFor(() => SelectedAction.Animation.IsRunning == false);
    //    // Run UpdateGame() next frame;
    //}

    private void RunAction(ActionDescription action)
    {
        action.Execute(State);
    }

    private IEnumerable<ActionDescription> SelectActionsViaProbability(GameState state)
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
        for (var _ = 0; _ < 4; _++)
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

    public void EndGame()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(EndScene.SceneName);
    }
}
