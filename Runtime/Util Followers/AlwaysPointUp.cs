using UnityEngine;
public class AlwaysPointUp : MonoBehaviour
{
    public enum Axis{xAxis, yAxis, zAxis};
    public bool isPositiveAxis;
    public Axis axis;
    void Update()
    {
        switch (axis)
        {
            case Axis.xAxis:
                {
                    if (isPositiveAxis)
                        transform.up = Vector3.left;
                    else
                        transform.up = Vector3.right;
                    break;
                }
            case Axis.yAxis:
                {
                    if (isPositiveAxis)
                        transform.up = Vector3.up;
                    else
                        transform.up = Vector3.down;
                    break;
                }
            case Axis.zAxis:
                {
                    if (isPositiveAxis)
                        transform.up = Vector3.back;
                    else
                        transform.up = Vector3.forward;
                    break;
                }
        }
    }
}
