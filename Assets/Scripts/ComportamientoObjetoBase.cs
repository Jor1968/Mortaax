using UnityEngine;
using System.Collections;

public class ComportamientoObjetoBase : MonoBehaviour
{
    public int Vida;
    public bool Vivo;
    public int TemporizadorBorrar = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Dañar(int Cantidad)
    {
        Vida = Vida - Cantidad;
        if(Vida <= 0 && Vivo == true)
        {   
            Vivo = false;
            Morir();
        }
    }
    /*public void EmpezarConteoBorrar()
    {
        Debug.Log("OH NO ESTOY SIENDO BORRADO AAAAAAAH");
        BorrarObjetoInutil = true;
    }
    */
    public IEnumerator EmpezarConteoBorrar()
{
    WaitForSeconds delay = new WaitForSeconds(1);
    while (true)
    {
        if(TemporizadorBorrar > 2)
        {
            Destroy(gameObject);
        }
        TemporizadorBorrar += 1;
        yield return delay;
    }
}
    public virtual void Morir()
    {
        Destroy(gameObject);

    }

    public IEnumerator TemporizadorDesabilitar(GameObject coso)
{   int segundos = 0;
    WaitForSeconds delay = new WaitForSeconds(0.2f);
    while (true)
    {
        if(segundos > 0.2f)
        {
            coso.SetActive(false);
            StopCoroutine("TemporizadorDesabilitar");
        }
        segundos += 1;
        yield return delay;
    }
}
    
}
