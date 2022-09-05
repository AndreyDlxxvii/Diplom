using UnityEditor;
using UnityEngine;
[CustomPropertyDrawer(typeof(ColorPoint))]
public class ColorDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);
        var contentPos = EditorGUI.PrefixLabel(position, label);
        if (SmallWidth())
        {
            position.height = 16f;
            EditorGUI.indentLevel += 1;
            contentPos = EditorGUI.IndentedRect(position);
            contentPos.y += 18f;
        }
        contentPos.width *= 0.75f;
        EditorGUI.indentLevel = 0;
        EditorGUI.PropertyField(contentPos, property.FindPropertyRelative("Position"), GUIContent.none);
        contentPos.x += contentPos.width;
        contentPos.width /= 3f;
        EditorGUIUtility.labelWidth = 14f;
        EditorGUI.PropertyField(contentPos, property.FindPropertyRelative("Color"), new GUIContent("C"));
        EditorGUI.EndProperty();
    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return SmallWidth() ? 16f + 18f : 18f;
    }
    private static bool SmallWidth()
    {
        return Screen.width < 419;
    }
}