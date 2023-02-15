using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    [SerializeField] private string _name;
    [SerializeField] private List<Dialog> _dialogs;

    private int _index = 0;
    
    public void Execute()
    {
        //dialog choice
        List<Condition> conditions = ValueDontDestroyOnLoad.Instance.ConditionsList.Find(x => x.Name == _name).Conditions;
        Dialog dialog = new Dialog();
        foreach (Condition condition in conditions)
        {
            if (condition.IsTrue)
            {
                print(condition.Name);
                dialog = _dialogs.Find(x => x.Condition == condition.Name);
            }
        }

        string index = _index == 0 ? " " : "";
        _index = _index == 0 ? 1 : 0;
        string text = $"{_name} : {dialog.DialogText}{index}";

        //show dialog
        GameManager.Instance.ShowDialog(text);
        
        //manage conditions
        if (dialog.ActivateAnotherConditionAtEnd)
        {
            ValueDontDestroyOnLoad.Instance.ActivateCondition(dialog.ConditionToActivateAtEnd, dialog.ConditionToActivateAtEnd, true);
        }
        
        //coroutine hide
        StartCoroutine(GameManager.Instance.HideDialog(2));
    }
}

[Serializable]
public struct Dialog
{
    public string Condition;
    [TextArea] public string DialogText;
    public bool ActivateAnotherConditionAtEnd;
    public string ConditionHolderToActivateAtEnd;
    public string ConditionToActivateAtEnd;
}

