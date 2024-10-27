using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;  

public class DialogueManager : MonoBehaviour
{
    public Image portraitImage;
    public Image dialogueFrameImage;
    public TMP_Text dialogueText;

    [System.Serializable]
    public class DialogueLine
    {
        public Sprite portrait;
        public string text;
    }

    public DialogueLine[] dialogueLines;
    private int currentLineIndex = 0;
    private bool isDialogueActive = false;

    private DialogueControls dialogueControls;  

    private void Awake()
    {
        dialogueControls = new DialogueControls();  

        // Bind actions to methods
        dialogueControls.Text.AdvanceDialogue.performed += _ => ShowNextLine();
        dialogueControls.Text.BackDialogue.performed += _ => ShowPreviousLine();
        dialogueControls.Text.SkipDialogue.performed += _ => SkipAllLines();
    }

    private void OnEnable()
    {
        dialogueControls.Text.Enable(); 
    }

    private void OnDisable()
    {
        dialogueControls.Text.Disable(); 
    }

    private void Start()
    {
        ShowDialogue(); 
    }

    public void DisplayDialogueLine(int lineIndex)
    {
        if (lineIndex >= 0 && lineIndex < dialogueLines.Length)
        {
            DialogueLine line = dialogueLines[lineIndex];
            portraitImage.sprite = line.portrait;
            dialogueText.text = line.text;
        }
    }

    public void ShowNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            DisplayDialogueLine(currentLineIndex);
        }
        else
        {
            Debug.Log("End of dialogue.");
            HideDialogue();
        }
    }

    public void ShowPreviousLine()
    {
        if (currentLineIndex > 0)
        {
            currentLineIndex--;  
            DisplayDialogueLine(currentLineIndex);
        }
    }

    public void SkipAllLines()
    {
        currentLineIndex = dialogueLines.Length - 1; 
        DisplayDialogueLine(currentLineIndex);
        HideDialogue();
    }

    public void HideDialogue()
    {
        portraitImage.gameObject.SetActive(false);
        dialogueFrameImage.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        isDialogueActive = false;
        dialogueControls.Text.Disable();  
    }

    public void ShowDialogue()
    {
        portraitImage.gameObject.SetActive(true);
        dialogueFrameImage.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        currentLineIndex = 0;
        DisplayDialogueLine(currentLineIndex);
        isDialogueActive = true;
        dialogueControls.Text.Enable(); 
    }
}
