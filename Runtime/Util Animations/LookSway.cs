using UnityEngine;

// Attach to object which parents the camera and does not have other scripts affecting the transform
[HelpURL("https://forum.unity.com/threads/free-head-sway-script.427983/")]
public class LookSway : MonoBehaviour
{
    public float HorizontalAmplitude = 0.01f;
    public float VerticalAmplitude = 0.12f;
    public float BaseSpeed = 1.25f;

    private Vector3 movement;
    private float progress;
    Quaternion quat;

    private void Start()
    {
        movement = Vector3.zero;
        quat = transform.localRotation;
    }

    private void Update()
    {
        progress = (progress + (Time.deltaTime * BaseSpeed) * (Random.Range(0f, 2f))) % (2 * Mathf.PI);
        movement.x = VerticalAmplitude * Mathf.Cos(progress + Mathf.PI / 2);
        movement.z = HorizontalAmplitude * Mathf.Sin(Mathf.PI / 2 - 2 * progress);
        //reference starting rotation and add/subtract from that
        transform.localEulerAngles = quat.eulerAngles + movement * 10;
    }
}