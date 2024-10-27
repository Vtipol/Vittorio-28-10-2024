using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditDialogLineWindow : EditorWindow
{
    private DialogLine dialogLine;

    public static void ShowWindow(DialogLine line)
    {
        EditDialogLineWindow window = GetWindow<EditDialogLineWindow>("Edit Dialog Line");
        window.dialogLine = line;
    }

    private void OnGUI()
    {
        if (dialogLine != null)
        {
            dialogLine.speaker = EditorGUILayout.TextField("Speaker:", dialogLine.speaker);
            dialogLine.text = EditorGUILayout.TextField("Text:", dialogLine.text);
        }
    }
}
