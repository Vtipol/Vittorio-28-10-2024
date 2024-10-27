using Unity;
using UnityEditor;
using System.Collections.Generic;

[System.Serializable]
public class DialogLine
{
    public string speaker;
    public string text;
}

[System.Serializable]
public class Dialog
{
    public string dialogName;
    public List<DialogLine> lines = new List<DialogLine>();
}
