using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    [SerializeField] private string _startDialog;
    [SerializeField, ReadOnly] private string _dialogIDToExecute;
    [SerializeField] private List<ConditionToDialog> _dialogsListAndCondition;
    
    private void Start()
    {
        _dialogIDToExecute = _startDialog;
    }

    public void Execute()
    {

        List<Condition> conditions = GameManager.Instance.ConditionList.Conditions;
        _dialogIDToExecute = _dialogsListAndCondition
            .Find(x => conditions.Find(y => y.ConditionID == x.ConditionToBeTrue).IsTrue).DialogID;
        
        string text = GameManager.Instance.DialogList.Dialogs.Find(x => x.DialogID == _dialogIDToExecute).Dialog;
        
        GameManager.Instance.DialogText.text = text;
    }
}

[Serializable]
public struct ConditionToDialog
{
    public string ConditionToBeTrue;
    public string DialogID;
}
