using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Ink.Runtime;

public class DialogueTrigger : MonoBehaviour
{
   [Header("Visual Cue")]
   [Header("Ink JSON")]
   [SerializeField] private TextAsset inkJSON;
   [SerializeField] private GameObject visualCue;

    private bool playerInRange;
    private PlayerInputManager InputManager;

   private void Awake() {
    playerInRange = false;
    visualCue.SetActive(false);
   }

   private void Update()
{
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) 
    {
        Debug.Log("Player in range");
        visualCue.SetActive(true);

        // Check if space bar is pressed
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!DialogueManager.GetInstance().dialogueIsPlaying)
            {
                // Enter dialogue mode
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }

            else if (DialogueManager.GetInstance().dialogueIsPlaying)
            {
                // Continue to next line if story can continue
                if (DialogueManager.GetInstance().currentStory.canContinue)
                {  
                    DialogueManager.GetInstance().ContinueStory();
                }
            else
            {
                // Exit dialogue mode if story is finished
                DialogueManager.GetInstance().ExitDialogueMode();
            }
        }
    }
    }
    else
    {
        visualCue.SetActive(false);
    }
    
}


   void OnTriggerEnter2D(Collider2D collider) {
    if(collider.gameObject.tag == "Player")
    {
        playerInRange = true;
    }
   }

    void OnTriggerExit2D(Collider2D collider) {
    if(collider.gameObject.tag == "Player")
    {
        playerInRange = false;
    }
   }

}
        


