using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionDescription : MonoBehaviour
{
    public ActionAnimation Animation;
    public abstract string Description();
    public abstract int EvaluateProbability(GameState state);
    public abstract void Execute(GameState state);  
    
}
