using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestMenu : MonoBehaviour
{
    public Quest quest;
    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (questWindow.activeSelf)
            {
                questWindow.SetActive(false);
                Debug.Log("Closed quest window");
            }
            else
            {
                OpenQuestWindow();
                Debug.Log("Opened quest window");
            }
        }
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
    }

    
    
}