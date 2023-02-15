using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class ObjectHitActivateDialogCondition : MonoBehaviour, IInteractable
{
    [SerializeField] private string _NPCName;
    [SerializeField] private string _conditionName;
    [SerializeField] private bool _activate;
    public void Execute()
    {
        ValueDontDestroyOnLoad.Instance.ActivateCondition(_NPCName, _conditionName, _activate);
    }
}
