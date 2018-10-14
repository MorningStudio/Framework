using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExcelImportWindow : EditorWindow
{
    [MenuItem("Window/QuickSheet/Test")]
    public static void Init()
    {
        ExcelImportWindow window = EditorWindow.GetWindow<ExcelImportWindow>();
        window.titleContent = new GUIContent("Excel Import Setting");
        window.Show();
        
    }

    private void OnGUI()
    {
        
    }
}
