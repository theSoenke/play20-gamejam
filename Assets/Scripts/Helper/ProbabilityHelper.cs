using UnityEngine;

public static class ProbabilityHelper
{
    public static int CalcWithMinimum(float value, float minValue, float maxValue, float maxProbability)
    {
        if (value < minValue)
            return 0;

        return Mathf.RoundToInt(((value - minValue) / (maxValue - minValue)) * maxProbability);
    }
}
