#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(RequireInterfaceAttribute))]
public class RequireInterfaceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        RequireInterfaceAttribute requireInterface = (RequireInterfaceAttribute)attribute;
        Type requiredType = requireInterface.RequiredType;

        // Проверка для массива или списка
        if (property.isArray && property.propertyType == SerializedPropertyType.Generic)
        {
            DrawArrayField(position, property, label, requiredType);
        }
        else if (property.propertyType == SerializedPropertyType.ObjectReference)
        {
            DrawSingleField(position, property, label, requiredType);
        }
        else
        {
            EditorGUI.LabelField(position, label.text, "Используйте [RequireInterface] только с объектами, массивами или списками компонентов.");
        }
    }

    private void DrawSingleField(Rect position, SerializedProperty property, GUIContent label, Type requiredType)
    {
        EditorGUI.BeginProperty(position, label, property);
        property.objectReferenceValue = ValidateObjectField(EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(MonoBehaviour), true), requiredType);
        EditorGUI.EndProperty();
    }

    private void DrawArrayField(Rect position, SerializedProperty property, GUIContent label, Type requiredType)
    {
        EditorGUI.BeginProperty(position, label, property);
        property.isExpanded = EditorGUI.Foldout(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), property.isExpanded, label);

        if (property.isExpanded)
        {
            EditorGUI.indentLevel++;

            SerializedProperty arraySizeProp = property.FindPropertyRelative("Array.size");
            EditorGUI.PropertyField(new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight), arraySizeProp);

            for (int i = 0; i < property.arraySize; i++)
            {
                SerializedProperty element = property.GetArrayElementAtIndex(i);
                Rect elementPosition = new Rect(position.x, position.y + (i + 2) * EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);
                element.objectReferenceValue = ValidateObjectField(EditorGUI.ObjectField(elementPosition, $"Element {i}", element.objectReferenceValue, typeof(MonoBehaviour), true), requiredType);
            }

            EditorGUI.indentLevel--;
        }

        EditorGUI.EndProperty();
    }

    private UnityEngine.Object ValidateObjectField(UnityEngine.Object obj, Type requiredType)
    {
        if (obj == null) return null;

        MonoBehaviour component = obj as MonoBehaviour;
        if (component != null && requiredType.IsAssignableFrom(component.GetType()))
        {
            return component;
        }
        else
        {
            if (component != null)
            {
                Debug.LogWarning($"Объект {component.name} не реализует интерфейс {requiredType.Name}");
            }
            return null;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (!property.isArray)
        {
            return EditorGUIUtility.singleLineHeight;
        }
        else if (property.isExpanded)
        {
            return EditorGUIUtility.singleLineHeight * (property.arraySize + 2);
        }
        else
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}
#endif