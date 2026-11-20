using UnityEngine;
using System.Collections;

public class ComportamientoExplosivo : ComportamientoObjetoBase
{
    public GameObject Explosion;
    public Rigidbody2D cuerpo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void explotar()
    {
        //cuerpo.bodyType = RigidbodyType2D.Static;
        cuerpo.mass = 500;
        cuerpo.constraints = RigidbodyConstraints2D.FreezeAll;
        Explosion.SetActive(true);
        StartCoroutine("EmpezarConteoBorrar");
    }
}
