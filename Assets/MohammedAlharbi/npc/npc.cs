using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueUI; 
    public Text dialogueTextUI;   
    public GameObject interactPrompt; 

    private bool isPlayerNearby = false;

    void Start()
    {
        if (dialogueUI != null)
            dialogueUI.SetActive(false); 

        if (interactPrompt != null)
            interactPrompt.SetActive(false); 
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDialogue();
        }
    }

    private void ToggleDialogue()
    {
        if (dialogueUI.activeSelf)
        {
            dialogueUI.SetActive(false); 
            if (interactPrompt != null)
                interactPrompt.SetActive(true); 
        }
        else
        {
            dialogueUI.SetActive(true);  
            if (interactPrompt != null)
                interactPrompt.SetActive(false); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactPrompt != null)
                interactPrompt.SetActive(true); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            if (dialogueUI != null)
                dialogueUI.SetActive(false); 

            if (interactPrompt != null)
                interactPrompt.SetActive(false); 
        }
    }
}
