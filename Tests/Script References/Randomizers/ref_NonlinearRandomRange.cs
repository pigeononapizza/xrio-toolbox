//http://www.babagazeus.com/articles/animation_curve_ranges/
//https://answers.unity.com/questions/871029/non-uniform-random-number.html
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ref_NonlinearRandomRange : MonoBehaviour
{
    //Dictionary<int, int> numCount = new Dictionary<int, int>();
    public Vector2 minMax = new Vector2(0, 10);
    public AnimationCurve animCurve;
    public int sampleCount = 300;

    public int[] numCount;

    void Start()
    {
        //float result = Mathf.Clamp(animCurve.Evaluate(Random.value), 0, 1);

    }

    public void GetNonLinearRandom()
    {
        numCount = new int[(int)(minMax.y - minMax.x) + 1];
        string printable = "";
        for (int i = 0; i < sampleCount; i++)
        {
            //************GOLD
            float result = Mathf.Clamp(animCurve.Evaluate(Random.value), 0, 1);
            //round to nearest int 
            float remap = Maths.Remap(result, 0, 1, minMax.x, minMax.y);
            //print(remap);
            int result_rounded = Mathf.RoundToInt(remap);
            //print(result_rounded);
            //************END GOLD
            int temp = numCount[result_rounded];
            temp++;
            numCount[result_rounded] = temp;
        }

        for (int i = 0; i < numCount.Length; i++)
        {
            printable = "\n" + i.ToString() + ": " + numCount[i].ToString();
        }

    }
}

