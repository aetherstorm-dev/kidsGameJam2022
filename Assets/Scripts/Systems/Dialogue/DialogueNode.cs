using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu]
public class DialogueNode : ScriptableObject
{
    public LocalizedString text;
    public bool empty;

    public DialogueCondition[] conditions;
    
    [Header("Actions")]
    public DialogueAction[] beforeActions;
    public DialogueAction[] afterActions;

    public DialogueNode[] nodes;
}

[Serializable]
public class DialogueCondition
{
    public enum Comparison { 
        [InspectorName("<")]  LessThan,
        [InspectorName("<=")] LessThanOrEqual,
        [InspectorName("=")]  Equal,
        [InspectorName(">")]  MoreThan,
        [InspectorName(">=")] MoreThanOrEqual,
    }

    public string key;
    public Comparison comparison;
    public int value;
}

[Serializable]
public class DialogueAction
{
    public enum Action
    {
        TriggerAction,
        SetVariable,
        AddVariable,
        ClearVariable,
    }

    public Action action;
    public string key;
    public string value;
}
