using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(DialogueCondition))]
public class DialoguePropertyDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();

        var keyField = new PropertyField(property.FindPropertyRelative("key"));
        var comparisonField = new PropertyField(property.FindPropertyRelative("comparison"));
        var valueField = new PropertyField(property.FindPropertyRelative("value"));

        container.Add(keyField);
        container.Add(comparisonField);
        container.Add(valueField);

        return container;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var keyRect = new Rect(position.x, position.y, position.width - 120, position.height);
        var comparisonRect = new Rect(position.x + (position.width - 120), position.y, 30, position.height);
        var valueRect = new Rect(position.x + (position.width - 120 + 30), position.y, 60, position.height);

        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(keyRect, property.FindPropertyRelative("key"), GUIContent.none);
        EditorGUI.PropertyField(comparisonRect, property.FindPropertyRelative("comparison"), GUIContent.none);
        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
