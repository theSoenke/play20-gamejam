using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePropertyValue
{
    public Type Type;
    public abstract object GetValue();
}
