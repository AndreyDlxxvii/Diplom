using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
[CustomEditor(typeof(HW9))]
public class HW9Editor : Editor
{
    private HW9 _hw9;

    public void OnEnable()
    {
        _hw9 = (HW9)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Show"))
        {
            _hw9.ShowSomeOne();
        }
    }
}
