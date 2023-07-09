using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumUtil : MonoBehaviour
{
    public enum TestTypes {type1, type2, misc};
    public TestTypes TestType = TestTypes.type1;
    void Start()
    {
        print($"Enum TestType is {TestType}"); //prints type1
        print($"Enum TestType is {TestType.ToString()}"); //prints type1
        print($"Enum TestType is {((byte)TestType)}");//prints 0
    }

}
