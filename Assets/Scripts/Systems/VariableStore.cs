using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VariableStore : ScriptableObject, ISerializationCallbackReceiver
{
    public IntValueRecord[] initialIntValues;
    public BoolValueRecord[] initialBoolValues;
    public StringValueRecord[] initialStringValues;

    [NonSerialized]
    private Dictionary<string, int> intValues;
    [NonSerialized]
    public Dictionary<string, bool> boolValues;
    [NonSerialized]
    public Dictionary<string, string> stringValues;

    // TODO: ValueUpdated events to subscribe to updates

    public void OnAfterDeserialize()
    {
        intValues = new Dictionary<string, int>();
        foreach (IntValueRecord record in initialIntValues)
        {
            intValues[record.key] = record.value;
        }

        boolValues = new Dictionary<string, bool>();
        foreach (BoolValueRecord record in initialBoolValues)
        {
            boolValues[record.key] = record.value;
        }

        stringValues = new Dictionary<string, string>();
        foreach (StringValueRecord record in initialStringValues)
        {
            stringValues[record.key] = record.value;
        }
    }

    public void OnBeforeSerialize()
    {
        
    }

    public int GetInt(string key)
    {
        return intValues.GetValueOrDefault(key, 0);
    }

    public void SetInt(string key, int value)
    {
        intValues[key] = value;
    }

    public void AddInt(string key, int value)
    {
        intValues[key] = intValues.GetValueOrDefault(key, 0) + value;
    }

    public bool GetBool(string key)
    {
        return boolValues.GetValueOrDefault(key, false);
    }

    public void SetBool(string key, bool value)
    {
        boolValues[key] = value;
    }

    public string GetString(string key)
    {
        return stringValues.GetValueOrDefault(key, "");
    }

    public void SetString(string key, string value)
    {
        stringValues[key] = value;
    }
}

[Serializable]
public class IntValueRecord
{
    public string key;
    public int value;
}

[Serializable]
public class BoolValueRecord
{
    public string key;
    public bool value;
}

[Serializable]
public class StringValueRecord
{
    public string key;
    public string value;
}
