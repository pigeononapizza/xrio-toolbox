using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class SimpleDoScale : DebugBehaviour
{
    public enum ScaleTargetType { ThisObject, OtherObject };
    [SerializeField] ScaleTargetType scaleTargetType = ScaleTargetType.ThisObject;
    [SerializeField, ShowIf("@scaleTargetType == ScaleTargetType.OtherObject")] private Transform scaleTarget;
    public enum ScaleType { Vector3, SingleValue };
    [SerializeField] private ScaleType scaleType = ScaleType.SingleValue;
    public enum StartScaleType { UseTargetScale, OverrideTargetScale }
    [SerializeField] private StartScaleType startScaleType = StartScaleType.UseTargetScale;

    [Header("Scale Parameters")]
    [SerializeField, ShowIf("@scaleType == ScaleType.Vector3 && startScaleType == StartScaleType.OverrideTargetScale")]
    private Vector3 startScale = Vector3.one;
    [SerializeField, ShowIf("@scaleType == ScaleType.Vector3")] private Vector3 endScale = Vector3.one * 2;
    [SerializeField, ShowIf("@scaleType == ScaleType.SingleValue&& startScaleType == StartScaleType.OverrideTargetScale")]
    private float startScaleVal = 1f;
    [SerializeField, ShowIf("@scaleType == ScaleType.SingleValue")] private float endScaleVal = 1f;

    [SerializeField] Ease startEase = Ease.Linear;
    [SerializeField] Ease endEase = Ease.Linear;
    [SerializeField] float duration = 1.0f;

    [Header("Events")]
    public UnityEvent onScalingComplete;
    public UnityEvent onReverseScalingComplete;

    private void Start()
    {
        if (scaleTargetType == ScaleTargetType.ThisObject)
        {
            scaleTarget = this.transform;
        }
        // Initialize the object with the start scale
        if (startScaleType == StartScaleType.UseTargetScale)
        {
            startScale = new Vector3(scaleTarget.localScale.x, scaleTarget.localScale.y, scaleTarget.localScale.z);
            ScaleTypeConversion();
        }
    }

    public void StartScaling()
    {
        ScaleTypeConversion();
        // Use DoTween to scale the object
        scaleTarget.DOScale(endScale, duration)
            .SetEase(startEase)
            .OnComplete(() =>
            {
                DebugMessage("Scaling completed.");
                onScalingComplete.Invoke();
            });
    }

    public void ReverseScaling()
    {
        ScaleTypeConversion();
        // Use DoTween to reverse the scaling back to the start scale
        scaleTarget.DOScale(startScale, duration)
            .SetEase(endEase)
            .OnComplete(() =>
            {
                DebugMessage("Scaling reversed.");
                onReverseScalingComplete.Invoke();
            });
    }

    private void ScaleTypeConversion()
    {
        if (scaleType == ScaleType.SingleValue)
        {
            startScale = startScaleType == StartScaleType.OverrideTargetScale ? Vector3.one * startScaleVal : startScale;
            endScale = Vector3.one * endScaleVal;
        }
    }
}
