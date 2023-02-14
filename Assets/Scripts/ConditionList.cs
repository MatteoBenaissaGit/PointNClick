using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionList : MonoBehaviour
{
    public List<Condition> Conditions;
}

[Serializable]
public struct Condition
{
    public string ConditionID;
    public bool IsTrue;
}
