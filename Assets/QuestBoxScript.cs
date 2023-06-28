using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBoxScript : MonoBehaviour
{
    public GameObject questPrefab;
    public Transform contentPanel;

    public void AddQuest(string title, string description)
    {
        // Instantiate the quest prefab
        GameObject newQuest = Instantiate(questPrefab, contentPanel);

        // Set the Title and Description text components
        newQuest.transform.Find("Title").GetComponent<Text>().text = title;
        newQuest.transform.Find("Description").GetComponent<Text>().text = description;
    }
}
