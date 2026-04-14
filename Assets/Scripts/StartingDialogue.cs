using UnityEngine;
using TMPro;
using System.Collections;

public class StartingDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;
    public float timeBetweenLines = 1f;

    public void PlayDialogue()
    {
        if (dialogueText == null) return;
        StartCoroutine(StartDialogue());
    }

    IEnumerator StartDialogue()
    {
        for (int i = 0; i < dialogueLines.Length; i++)
        {
            dialogueText.text = "";

            for (int j = 0; j < dialogueLines[i].Length; j++)
            {
                dialogueText.text += dialogueLines[i][j];
                yield return new WaitForSeconds(Random.Range(typingSpeed * 0.8f, typingSpeed * 1.2f));
            }

            yield return new WaitForSeconds(timeBetweenLines);
        }

        dialogueText.text = "";
    }
}