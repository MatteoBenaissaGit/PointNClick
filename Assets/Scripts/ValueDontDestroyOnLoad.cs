using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ValueDontDestroyOnLoad : MonoBehaviour
{
    [ReadOnly] public static ValueDontDestroyOnLoad Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            
            //playerprefs
            PlayerPrefs.DeleteKey("positionX");
            PlayerPrefs.DeleteKey("positionY");
            if (PlayerPrefs.HasKey("scale"))
            {
                PlayerPrefs.DeleteKey("scale");
            }
            
            //values
            PlayerBaseScale = Vector3.one * 3.5f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<ConditionList> ConditionsList;
    public Vector3 PlayerBaseScale;

    public void ActivateCondition(string characterName, string conditionName, bool activate)
    {
        print($"activate {characterName}-{conditionName}:{activate}");

        //set all conditions to false
        List<Condition> conditions = new List<Condition>();
        foreach (Condition condition in ConditionsList.Find(x => x.Name == characterName).Conditions)
        {
            Condition newConditionFalse = new Condition() { Name = condition.Name, IsTrue = false };
            conditions.Add(newConditionFalse);
        }
        ConditionsList.Remove(ConditionsList.Find(x => x.Name == characterName));
        ConditionsList.Add(new ConditionList(){Name = characterName, Conditions = conditions});

        //set the wanted condition to true
        Condition newCondition = new Condition() { Name = conditionName, IsTrue = activate };
        ConditionsList.Find(x => x.Name == characterName).Conditions
            .Remove(ConditionsList.Find(x => x.Name == characterName).Conditions.Find(x => x.Name == conditionName));
        ConditionsList.Find(x => x.Name == characterName).Conditions.Add(newCondition);
    }
}

[Serializable]
public struct ConditionList
{
    [FormerlySerializedAs("NPCName")] public string Name;
    public List<Condition> Conditions;
}

[Serializable]
public struct Condition
{
    public string Name;
    public bool IsTrue;
}