using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogList : MonoBehaviour
{
    public List<DialogIdentifier> Dialogs;
}


[Serializable]
public struct DialogIdentifier
{
    public string DialogID;
    public string CharacterName;
    public string Dialog;
}
