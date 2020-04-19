using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] GameObject dialogueCanvas;
    [SerializeField] Text dialogueText;

    bool isActive = false;

    private void Start() {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isActive) {
                isActive = false;
                FindObjectOfType<GameController>().UnpauseGame();
                dialogueCanvas.SetActive(false);
                dialogueText.text = "";
            }
        }
    }

    public void Activate(string displayText) {
        isActive = true;
        FindObjectOfType<GameController>().PauseGame();
        dialogueCanvas.SetActive(true);
        dialogueText.text = displayText;
    }
}
