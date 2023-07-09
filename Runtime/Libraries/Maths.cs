using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Maths 
{
    public static float Remap(this float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        float fromAbs = from - fromMin;
        float fromMaxAbs = fromMax - fromMin;

        float normal = fromAbs / fromMaxAbs;

        float toMaxAbs = toMax - toMin;
        float toAbs = toMaxAbs * normal;

        float to = toAbs + toMin;

        return to;
    }
    /// <summary>
    /// Use FisherYates (FY) to randomize the order of an array. 
    /// Example: [1,2,3,4] > [3,1,4,2]
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>

    public static int[] FisherYates_Shuffle(int[] a)
    {

        // Loops through array
        for (int i = a.Length - 1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = Random.Range(0, i);

            // Save the value of the current i, otherwise it'll overright when we swap the values
            int temp = a[i];

            // Swap the new and old values
            a[i] = a[rnd];
            a[rnd] = temp;
        }

        string res = "";
        // Print
        for (int i = 0; i < a.Length; i++)
        {
            res += a[i];
        }

        //Debug.Log(res);
        return a;
    }

}

