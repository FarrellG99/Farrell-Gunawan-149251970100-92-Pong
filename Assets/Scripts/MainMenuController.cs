using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame(){
        Debug.Log("Created By Farrell Gunawan - 149251970100-92");
        SceneManager.LoadScene("Game");
    }

    public void OpenAuthor(){
        Debug.Log("Created By Farrell Gunawan - 149251970100-92");
    }
}
