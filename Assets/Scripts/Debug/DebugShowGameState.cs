using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugShowGameState : MonoBehaviour
{
    public Text DrunkValueText;
    public Text SusValueText;

    void Start()
    {
        GameStateManager.Instance.GamePhaseChanged += OnGamePhaseChanged;
    }

    private void OnGamePhaseChanged(GamePhase phase)
    {
        if (phase == GamePhase.AnimatingAction) 
        {
            DrunkValueText.text = GameStateManager.Instance.State.Drunk.ToString("0.0");
            SusValueText.text = GameStateManager.Instance.State.Sus.ToString("0.0");
        }
    }
}
