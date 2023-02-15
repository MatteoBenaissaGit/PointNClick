using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectHitActivateDialogCondition : MonoBehaviour, IInteractable
{
    [SerializeField] private string NPCName;
    [SerializeField] private string ConditionName;
    [SerializeField] private bool Activate;
    public void Execute()
    {
        ValueDontDestroyOnLoad.Instance.ActivateCondition(NPCName, ConditionName, Activate);
    }
}
