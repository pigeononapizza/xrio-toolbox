using UnityEngine;

public class OnStart_ParentTo : MonoBehaviour
{
    [SerializeField] Transform _newParent;
    void Start()
    {
        transform.SetParent(_newParent, true);
    }


}
