using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    
    public string dialogueText = "Hello, traveler! Welcome to my village."; 
    public GameObject dialogueUI; 
    public Text dialogueTextUI; 

    private bool isPlayerNearby = false;

    void Start()
    {
        if (dialogueUI != null)
            dialogueUI.SetActive(false); 
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
        }
        else
        {
            dialogueUI.SetActive(true); 
            dialogueTextUI.text = dialogueText;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNearby = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (dialogueUI != null)
                dialogueUI.SetActive(false);
        }
    }
}
