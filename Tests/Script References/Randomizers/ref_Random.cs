using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ref_Random : MonoBehaviour
{
    //Random Ranges
    private void Start()
    {
        //Random in circle
        //https://docs.unity3d.com/ScriptReference/Random-insideUnitCircle.html
        Vector2 randInCircle_Vec2 = Random.insideUnitCircle * 5;
        Debug.Log($"Random value in circle is {randInCircle_Vec2}");
        Vector3 randInCircle_Vec3 = Random.insideUnitCircle * 5;
        Debug.Log($"Random value in circle is {randInCircle_Vec3}");

    }

}
