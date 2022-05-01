using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(DialogueAction))]
public class DialogueActionPD : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();

        var actionField = new PropertyField(property.FindPropertyRelative("action"));
        var keyField = new PropertyField(property.FindPropertyRelative("key"));
        var valueField = new PropertyField(property.FindPropertyRelative("value"));

        container.Add(actionField);
        container.Add(keyField);
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
        var actionRect = new Rect(position.x, position.y, 120, position.height);
        EditorGUI.PropertyField(actionRect, property.FindPropertyRelative("action"), GUIContent.none);

        int enumIndex = property.FindPropertyRelative("action").enumValueIndex;
        if (enumIndex < 3)
        {
            var keyRect = new Rect(position.x + 120, position.y, position.width - 210, position.height);
            var valueRect = new Rect(keyRect.x + keyRect.width, position.y, 90, position.height);

            EditorGUI.PropertyField(keyRect, property.FindPropertyRelative("key"), GUIContent.none);
            EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);
        }
        else
        {
            var keyRect = new Rect(position.x + 120, position.y, position.width - 120, position.height);

            // Draw fields - pass GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(keyRect, property.FindPropertyRelative("key"), GUIContent.none);
        }

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
