﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBalancingValues : MonoBehaviour
{
    public float SmallAmount = 5f;
    public float MediumAmount = 10f;
    public float BigAmount = 15f;

    public float this[Amounts a]
    {
        get
        {
            switch (a)
            {               
                case Amounts.Medium:
                    return MediumAmount;
                case Amounts.Big:
                    return BigAmount;
                default:
                    return SmallAmount;
            }
        }
    }    
}

[Serializable]
public enum Amounts
{
    Small,
    Medium,
    Big
}
