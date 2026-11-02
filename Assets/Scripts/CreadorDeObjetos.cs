using UnityEngine;
using System.Collections;
public class CreadorDeObjetos : MonoBehaviour
{
    public GameObject ObjetoSpawneado;
    public AudioSource sonido;
    public int Temporizador = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator TemporizadorSpawn()
{   int segundos = 0;
    WaitForSeconds delay = new WaitForSeconds(1f);
    while (true)
    {
        if(segundos > Temporizador)
        {
                if (!sonido.isPlaying)
                {
                    sonido.Play();
                }
            GameObject clone = Instantiate(ObjetoSpawneado, transform.position, Quaternion.identity);
            clone.GetComponent<ComportamientoCriaturaVoladora>().CasaSpawn = this.gameObject;
            StopCoroutine("TemporizadorSpawn");
        }
        segundos += 1;
        yield return delay;
    }
}
}
