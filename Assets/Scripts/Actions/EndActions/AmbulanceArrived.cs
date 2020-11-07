using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceArrived : ActionDescription
{
    public float SusValue = 10f;


    public override string Description(GameState state)
    {
        return "I am Okkeeee, faaaaaccccckkk uffff";
    }

    public override int EvaluateProbability(GameState state)
    {
    
        return 0;
    }

    public override void Execute(GameState state)
    {
 

    }   
}