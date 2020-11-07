using UnityEngine;

public class GameState : MonoBehaviour
{
    public float Drunk { get; protected set; }
    public float Sus { get; protected set; }
    public float PeeLevel { get; protected set; }
    public float Time { get; protected set; }

    public bool IsInside { get; protected set; }
    public bool IsGameOver { get; protected set;}

    public int Drinks { get; protected set; }

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        Time += UnityEngine.Time.deltaTime;
    }

    public void Drink(float value)
    {
        Drunk += value;
        Drunk = Mathf.Max(Drunk, 0);
        Drinks++;
        // TODO: Add Pee/PunkeLikeless Value etc.
    }

    public void SusAdd(float value)
    {
        Sus += value;
    }

    public void PissReset()
    {
        PeeLevel = 0f;
    }

    public void GoInside()
    {
        IsInside = true;
    }

    public void GameOver() {
        IsGameOver = true;
    }



    /// <summary>
    /// Call this when the Game Starts.
    /// </summary>
    public void ResetState()
    {
        Drunk = 0;
        Sus = 0;
        PeeLevel = 0;
        Time = 0;
        IsInside = false;
    }
}
