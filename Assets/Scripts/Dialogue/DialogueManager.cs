using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    public Story currentStory;
    public bool dialogueIsPlaying;
    private int currentChoiceIndex = -1; // current ink choice index (-1 means no choices have been presented yet)

    private static DialogueManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Found more than one DialogueManager in this scene");

        }
        instance = this;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public static DialogueManager GetInstance()
 {
     return instance;
 }

 

    private void Update() 
    {
        //return right away if dialogue isn't playing
        if(!dialogueIsPlaying)
        {
            return;
        }

        //handle continuing to the next line in the dialogue when space is pressed
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if(currentStory.canContinue)
            {
                ContinueStory();
            }
            else if(currentStory.currentChoices.Count > 0 && currentChoiceIndex < 0)
            {
                currentChoiceIndex = 0;
               // ShowChoices();
            }
            else
            {
                ExitDialogueMode();
            }
        }
        
        
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        Debug.Log("Entered Dialogue mode");

       // ContinueStory();

        
    }
        public void ExitDialogueMode()
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
            dialogueText.text = "";
            currentChoiceIndex = -1; // reset choice index
            Debug.Log("Exited dialogue mode");
        }

        public void ContinueStory()
        {
            if(currentStory.canContinue)
        {
            //set text for current dialogue line
            dialogueText.text = currentStory.Continue();
            //display choices, if any, for this dialogue line
            DisplayChoices();
        }

        // else if (currentStory.currentChoices.Count > 0 && currentChoiceIndex < 0)
        // {
        //     currentChoiceIndex = 0;
        //    // ShowChoices();
        // }
        else
        {
            Debug.Log("Reached end of Story");
            ExitDialogueMode();
            dialogueIsPlaying = false;
        }
        }

        private void DisplayChoices()
        {
            List<Choice> currentChoice = currentStory.currentChoices;

            if(currentStory.currentChoices.Count > choices.Length)
            {
                Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentStory.currentChoices.Count);
            }

            int index = 0;
            //enable and initialize the choices up to the amount of choices for this line of dialogue
            foreach(Choice choice in currentStory.currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = choice.text;
                index++;
            }
            //go through the remaining chouces the UI supports and make sure they're hidden
            for (int i = index; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }

            StartCoroutine(SelectFirstChoice());
        }

        private IEnumerator SelectFirstChoice()
        {
            //Event System requires we clear it first, then wait for a frame
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        }

        public void MakeChoice(int choiceIndex)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
        }

    //     private void ShowChoices()
    // {
    //     var choices = currentStory.currentChoices;
    //     var choiceText = "";
    //     for (int i = 0; i < choices.Count; i++)
    //     {
    //         choiceText += $"[{i+1}] {choices[i].text}\n";
    //     }
    //     dialogueText.text = choiceText;
    // }

    // public void SelectChoice(int choiceIndex)
    // {
    //     currentStory.ChooseChoiceIndex(choiceIndex);
    //     currentChoiceIndex = -1; // reset choice index
    //     ContinueStory();
    // }

     }

