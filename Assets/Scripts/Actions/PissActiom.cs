using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissActiom: ActionDescription
{
    public float SusValue = 10f;

    private void Awake()
    {
        //If(!Animation) AN = null;
    }

    public override int EvaluateProbability(GameState state)
    {
        return 100;
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(SusValue);   
        state.PissReset();  
    }

    public override string Description()
    {
        return "Oh have to take a piss so badly..";
    }
}
