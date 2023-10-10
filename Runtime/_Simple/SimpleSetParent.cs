using Sirenix.OdinInspector;
using UnityEngine;

public class SimpleSetParent : MonoBehaviour
{
    public enum AssignTypes { byGameObject, byName }
    [SerializeField] private AssignTypes childAssignType = AssignTypes.byGameObject;
    [SerializeField, ShowIf("@childAssignType == AssignTypes.byGameObject")] private GameObject childObject;
    [SerializeField, ShowIf("@childAssignType == AssignTypes.byName")] private string childObjectName;
    [SerializeField] private AssignTypes parentAssignType = AssignTypes.byName;
    [SerializeField, ShowIf("@parentAssignType == AssignTypes.byGameObject")] private GameObject parentObject;
    [SerializeField, ShowIf("@parentAssignType == AssignTypes.byName")] private string parentObjectName;

    [SerializeField] private bool keepWorldPositionStays = false;

    [Button]
    public void SetChildObjectToParentObject()
    {
        switch (childAssignType)
        {
            case AssignTypes.byGameObject:
                childObject = gameObject;
                break;
            case AssignTypes.byName:
                childObject = GameObject.Find(childObjectName);
                if (childObject == null)
                {
                    Debug.LogError("Child Object with name " + childObjectName + " not found.");
                    return;
                }
                break;
        }

        switch (parentAssignType)
        {
            case AssignTypes.byGameObject:
                parentObject = gameObject;
                break;
            case AssignTypes.byName:
                parentObject = GameObject.Find(parentObjectName);
                if (parentObject == null)
                {
                    Debug.LogError("Parent Object with name " + parentObjectName + " not found.");
                    return;
                }
                break;
        }

        if (childObject != null && parentObject != null)
        {
            childObject.transform.SetParent(parentObject.transform, keepWorldPositionStays);
        }
        else
        {
            Debug.LogError("Child or Parent object is null. Parenting operation failed.");
        }
    }

}
