using UnityEngine;

public class GameState : MonoBehaviour
{
    public float Drunk { get; protected set; }
    public float Sus { get; protected set; }
    public float PeeLevel { get; protected set; }
    public float Time { get; protected set; }
    public float Sickness { get; protected set; }

    public bool IsInside { get; protected set; }
    public bool IsGameOver { get; protected set; }

    public int Drinks { get; protected set; }

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        Time += UnityEngine.Time.deltaTime;
    }

    public void Drink(float strength, float volume)
    {
        Drunk += strength;
        Drunk = Mathf.Max(Drunk, 0);

        if (strength > 0 && volume > 0)
        {
            Drinks++;
        }

        Sickness += strength;

        PeeLevel += volume;
    }

    public void SoberUp(float sickness, float drunk)
    {
        Drunk -= drunk;
        Sickness -= sickness;
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

    public void GameOver()
    {
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
        Sickness = 0;
        IsInside = false;
        IsGameOver = false;
    }
}
