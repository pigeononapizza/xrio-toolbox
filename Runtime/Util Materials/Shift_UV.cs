using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Shift_UV : MonoBehaviour
{
    [Range(0f, 1f)]
    public float xOffset, yOffset;
    float previousXOffset, previousYOffset;
    void Update(){
        if (xOffset != previousXOffset || yOffset != previousYOffset){
            previousXOffset = xOffset;
            previousYOffset = yOffset;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(xOffset, yOffset);
        }
    }
    
}
