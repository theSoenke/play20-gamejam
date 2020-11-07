using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomString
{
    public static string Select(params string[] strings)
    {
        var rng = Random.Range(0, strings.Length);
        return strings[rng];
    }
}
