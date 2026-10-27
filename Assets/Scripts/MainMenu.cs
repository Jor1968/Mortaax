using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    public VideoPlayer marioSavio;
    public Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (startButton.IsPressed()){
            IniciarJuego();
        }
        if(marioSavio.isPaused){
        marioSavio.targetCameraAlpha = 0;
        }
    }
    void IniciarJuego()
    {
        SceneManager.LoadSceneAsync("Assets/Scenes/nivel47.unity");
    }
}
