using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AK.Wwise.Event MusicStop;
    public AK.Wwise.Event UI_Game_Start;
    public void Awake()
    {
        Cursor.visible = true;
    }

    public void LoadTheGame() {
        MusicStop.Post(gameObject);
        UI_Game_Start.Post(gameObject);
        SceneManager.LoadScene("Game");
    }
}
