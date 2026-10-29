using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class ControladorMenu : MonoBehaviour
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
        if(marioSavio.isPaused){
        marioSavio.targetCameraAlpha = 0;
        }
    }
    void IniciarJuego()
    {
        SceneManager.LoadSceneAsync("Assets/Scenes/nivel47.unity");
    }

    public void onExitButtonClick(){
        Application.Quit();
    }
    public void onstartButtonButtonClick(){
        IniciarJuego();
    }
    public void onClickVolverMenu()
    {
     SceneManager.LoadSceneAsync("Assets/Scenes/MainMenu.unity");
    }
}
