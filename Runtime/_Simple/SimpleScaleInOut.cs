using DG.Tweening;
using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;

public class SimpleScaleInOut : MonoBehaviour
{
    [SerializeField] private float tweenDuration = 0.5f;
    [SerializeField] private Ease tweenEaseType;
    [SerializeField] private GameObject scaleTarget;

    private Tweener tweener;

    [Button]
    public void ScaleIn()
    {
        scaleTarget.transform.localScale = Vector3.zero;
        scaleTarget.SetActive(true);
        tweener?.Kill();
        scaleTarget.transform.DOScale(1f, tweenDuration)
            .SetEase(tweenEaseType);
    }

    private IEnumerator DelayThenHide()
    {
        yield return new WaitForSeconds(4f);
        ScaleOut();
    }

    [Button]
    public void ScaleOut()
    {
        tweener?.Kill();
        scaleTarget.transform.DOScale(0f, tweenDuration)
            .SetEase(tweenEaseType)
            .OnComplete(() => scaleTarget.SetActive(false));
    }


}
