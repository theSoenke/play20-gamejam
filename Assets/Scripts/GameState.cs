using UnityEngine;

public class GameState : MonoBehaviour
{
    public float Drunk { get; protected set; }
    public float Sus { get; protected set; }
    public float PeeLevel { get; protected set; }


    public void Drink(float value)
    {
        Drunk += value;
        Drunk = Mathf.Max(Drunk, 0);
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
}
