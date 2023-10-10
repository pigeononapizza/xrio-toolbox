using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SimpleAssetPointer : MonoBehaviour
{
    [Sirenix.OdinInspector.InfoBox("This script is used during development to quickly access \n" +
        "assets normally buried deep within the heirarchy. \n" +
        "Place this at the root of the heirarchy and assign the assets you want to frequently access.")]

    [SerializeField] private Object[] assetsToPointTo;
}
