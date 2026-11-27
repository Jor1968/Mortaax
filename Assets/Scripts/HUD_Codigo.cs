using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class HUD_Codigo : MonoBehaviour
{
    public TextMeshProUGUI IndicadorVida;
    public TextMeshProUGUI IndicadorOroGremloide;
    public TextMeshProUGUI IndicadorTesoroGremloide;
    public TextMeshProUGUI ObjetoSeleccionadoTexto;
    public Image ObjetoSeleccionadoImagen;
    public Sprite spriteCascote;
    public Sprite spriteDinamita;
    public Sprite spriteTrabuco;
    public Dictionary<string, Sprite> diccionarioSprites = new Dictionary<string, Sprite>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diccionarioSprites.Add("trabuco",spriteTrabuco);
        diccionarioSprites.Add("dinamita",spriteDinamita);
        diccionarioSprites.Add("cascote",spriteCascote);
        
        foreach(string i in diccionarioSprites.Keys)
        {
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void actualizarVida(int Vida)
    {
        IndicadorVida.text = "Vida:" + Vida;
    }
    public void actualizarOro(int OroGremloide)
    {
        IndicadorOroGremloide.text = "Oro:" + OroGremloide;
    }
    public void actualizarTesoro(int TesorosAgarrados)
    {
        IndicadorTesoroGremloide.text = TesorosAgarrados + " De 3 Tesoros Agarrados.";
    }
    public void actualizarObjetoSeleccionado(string objeto)
    {
        Debug.Log(objeto);

        ObjetoSeleccionadoImagen.sprite = diccionarioSprites[objeto];
        //ObjetoSeleccionadoTexto.text = "Objeto Selec del INVENTARIO: \n" + objeto + ".";
        ObjetoSeleccionadoTexto.text = objeto;
    }
    public void GanarPartida()
    {
        SceneManager.LoadSceneAsync("Assets/Scenes/PantallaVictoria.unity");
    }
}
