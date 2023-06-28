using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameScript : MonoBehaviour
{
    
    void OnTriggerExit2D(Collider2D collider) {
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
   }
}
