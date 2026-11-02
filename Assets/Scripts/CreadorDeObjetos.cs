using UnityEngine;

public class CreadorDeObjetos : MonoBehaviour
{
    public GameObject ObjetoSpawneado;
    public AudioSource sonido;
    public float tiempoRestante = 0f;
    public float tiempoMinimo = 1.0f;
    public float tiempoMaximo = 3.0f;
    public float amplitud = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoRestante <= 0)
        {
            float desplazamiento = Random.Range(-amplitud, amplitud);
            Vector3 puntoDeSalida = new Vector3(desplazamiento, 0, 0);
            Instantiate(ObjetoSpawneado, transform.position + puntoDeSalida, Quaternion.identity);
            tiempoRestante = Random.Range(tiempoMinimo, tiempoMaximo);
            if (!sonido.isPlaying)
            {
                sonido.Play();
            }
        }

        tiempoRestante = tiempoRestante - Time.deltaTime;

    }
}
