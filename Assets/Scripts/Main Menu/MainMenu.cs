using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        Cursor.visible = true;
    }

    public void LoadTheGame() {
        SceneManager.LoadScene("Game");
    }
}
