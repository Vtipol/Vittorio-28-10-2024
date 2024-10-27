using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class DialogEditorWindow : EditorWindow
{
    private List<Dialog> dialogs = new List<Dialog>(); 
    private int selectedDialogIndex = -1;              
    private Vector2 scrollPosition;

    [MenuItem("Tools/Dialog Editor")]
    public static void ShowWindow()
    {
        GetWindow<DialogEditorWindow>("Dialog Editor");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Dialog Editor", EditorStyles.boldLabel);

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        for (int i = 0; i < dialogs.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Edit", GUILayout.Width(50)))
            {
                selectedDialogIndex = i;
            }
            if (GUILayout.Button("Delete", GUILayout.Width(50)))
            {
                dialogs.RemoveAt(i);
                if (selectedDialogIndex == i) selectedDialogIndex = -1;
                continue;
            }
            EditorGUILayout.LabelField(dialogs[i].dialogName);
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Add Dialog"))
        {
            dialogs.Add(new Dialog { dialogName = "New Dialog" });
        }

        if (selectedDialogIndex >= 0 && selectedDialogIndex < dialogs.Count)
        {
            DrawEditDialogWindow();
        }
    }

    private void DrawEditDialogWindow()
    {
        Dialog selectedDialog = dialogs[selectedDialogIndex];
        selectedDialog.dialogName = EditorGUILayout.TextField("Dialog Name:", selectedDialog.dialogName);

        for (int i = 0; i < selectedDialog.lines.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            selectedDialog.lines[i].speaker = EditorGUILayout.TextField("Speaker", selectedDialog.lines[i].speaker);
            selectedDialog.lines[i].text = EditorGUILayout.TextField("Text", selectedDialog.lines[i].text);
            if (GUILayout.Button("Delete Line", GUILayout.Width(100)))
            {
                selectedDialog.lines.RemoveAt(i);
            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Line"))
        {
            selectedDialog.lines.Add(new DialogLine { speaker = "Speaker", text = "New Line" });
        }
    }
}
