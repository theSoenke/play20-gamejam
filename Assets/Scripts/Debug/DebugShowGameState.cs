using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugShowGameState : MonoBehaviour
{
    public Text DrunkValueText;
    public Text SusValueText;
    public Text PeeValueText;
    public Text SickValueText;

    void Start()
    {
        GameStateManager.Instance.GamePhaseChanged += OnGamePhaseChanged;
    }

    private void OnGamePhaseChanged(GamePhase phase)
    {
        if (phase == GamePhase.PhaseComplete) 
        {
            DrunkValueText.text = GameStateManager.Instance.State.Drunk.ToString("0.0");
            SusValueText.text = GameStateManager.Instance.State.Sus.ToString("0.0");
            PeeValueText.text = GameStateManager.Instance.State.PeeLevel.ToString("0.0");
            SickValueText.text = GameStateManager.Instance.State.Sickness.ToString("0.0");
        }
    }

    public void EndGame()
    {
        GameStateManager.Instance.EndGame();
    }
}
