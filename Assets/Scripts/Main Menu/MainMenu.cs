using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        Cursor.visible = false;
    }

    public void LoadTheGame() {
        SceneManager.LoadScene("Game");
    }
}
