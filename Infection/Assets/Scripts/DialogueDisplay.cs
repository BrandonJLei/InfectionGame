using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueDisplay : MonoBehaviour
{
    public string[] dialogueLines;
    public Text dialogueText;

    private bool isPrinting;
    private int curDialogueIndex;

    private void Start()
    {
        isPrinting = false;
        curDialogueIndex = 0;
        dialogueText.text = "";
    }

    private IEnumerator PrintDialogue(string textToPrint)
    {
        int textIndex = 0;
        dialogueText.text = "";

        while(isPrinting == true)
        {
            dialogueText.text += textToPrint[textIndex];
            yield return null;
            textIndex++;
            if (textIndex >= textToPrint.Length)
            {
                isPrinting = false;
            }
        }
    }
}
