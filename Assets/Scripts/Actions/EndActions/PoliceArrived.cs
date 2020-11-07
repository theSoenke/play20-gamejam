using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceArrived : ActionDescription
{

  public override string Description(GameState state)
    {
        return "Shit  Cops";
    }

    public override int EvaluateProbability(GameState state)
    {
    
        return 0;
    }

    public override void Execute(GameState state)
    {
 

    }   
}