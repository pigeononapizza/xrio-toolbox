using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[HelpURL("http://www.alanzucconi.com/2015/07/26/enum-flags-and-bitwise-operators/")]
public class EnumFlags : MonoBehaviour
{
    [SerializeField] bool showDebug = true;
    [Flags]
    public enum AttackType
    {
        All = -1,
        None = 0,
        Melee = 1,
        Fire = 2,
        Ice = 4,
        Poison = 8
    }

    [SerializeField] Toggle[] toggles;
    [SerializeField] Toggle tog_all, tog_none;

    // ...
    public AttackType attackType = AttackType.Melee | AttackType.Fire;

    public AttackType compareType = AttackType.Fire;

    public void Start()
    {
        InvokeRepeating("DebugMatching", 1f, 1f);
    }

    void DebugMatching()
    {
        if (!showDebug) return;
        if (attackType.HasFlag(compareType))
        {
            Debug.Log("<color=green> MATCH </color>");
        }
        else
        {
            Debug.Log("<color=red> MIS-MATCH </color>");
        }
    }

    public static AttackType SetFlag(AttackType a, AttackType b)
    {
        return a | b;
    }
    public static AttackType UnsetFlag(AttackType a, AttackType b)
    {
        return a & (~b);
    }

    // Works with "None" as well
    public static bool HasFlag(AttackType a, AttackType b)
    {
        return (a & b) == b;
    }
    public static AttackType ToggleFlag(AttackType a, AttackType b)
    {
        return a ^ b;
    }

    bool busy = false;
    public void Tog_None()
    {
        if (busy) return;
        Debug.Log("Running tog_none");
        attackType ^= AttackType.None;
        foreach (var tog in toggles)
        {
            tog.isOn = false;
        }
        tog_none.isOn = true;
    }
    public void Tog_Melee()
    {
        if (busy) return;
        StartCoroutine(DoWait());

        attackType ^= AttackType.Melee;
    }
    public void Tog_Fire()
    {
        if (busy) return;
        StartCoroutine(DoWait());
        Debug.Log("Tog_Fire");

        attackType ^= AttackType.Fire;
    }
    public void Tog_Ice()
    {
        if (busy) return;
        StartCoroutine(DoWait());
        Debug.Log("Tog_Ice");
        attackType ^= AttackType.Ice;
    }
    public void Tog_All()
    {
        StartCoroutine(DoWait());
        if (attackType != AttackType.All)
        {
            Debug.Log("Tog_all > Tog_all");
            attackType = AttackType.All;
            foreach (var tog in toggles)
            {
                tog.isOn = true;
            }
            tog_none.isOn = false;
        }
        else
        {
            Debug.Log("Tog_all > Tog_none");
            attackType = AttackType.None;
            foreach (var tog in toggles)
            {
                tog.isOn = false;

            }
            tog_none.isOn = true;

        }
    }

    IEnumerator DoWait()
    {
        busy = true;
        tog_none.isOn = false;
        yield return new WaitForSeconds(.1f);
        busy = false;
    }

    //public void To


}
