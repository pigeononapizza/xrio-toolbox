using System;
using System.Collections.Generic;
using UnityEngine;

public class String_Utilities : MonoBehaviour
{
    string sampleString = "1This sample string(Clone)";
    void Start()
    {
        print("Original: " + sampleString);
        sampleString = sampleString.Substring(1, sampleString.Length - 1);
        print("Substring: " + sampleString);
        sampleString = sampleString.Replace("(Clone)", "");
        print("ReplacedString: " + sampleString);

        //https://docs.unity3d.com/Manual/BestPracticeUnderstandingPerformanceInUnity5.html
        string strangeString = "EnCycloPedia";
        string regularString = "encyclopedia";
        if (strangeString.Equals(regularString, StringComparison.Ordinal))
        {
            print($"Ordinal comparison said {strangeString} is equal to {regularString}");
        }

    }


}
