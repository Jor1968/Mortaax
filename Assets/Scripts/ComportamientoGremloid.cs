using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//using System.Numerics;
public class ComportamientoGremloid : ComportamientoObjetoBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float multiplicadorVelocidad = 20;
    public float multiplicadorSalto = 20;
    public int OroGremloide = 10;
    public int TesorosAgarrados = 0;
    public Vector3 velocity = new Vector3();
    public SpriteRenderer imagen;
    public Rigidbody2D cuerpo;
    public BoxCollider2D colisionadorPie;
    public bool estaEnElSuelo = true;
    public bool usandoPico = false;
    public bool usandoObjeto = false;
    public string objetoElegido;
    public int numeroInventario = 2;
    public Dictionary<int, string> inventario = new Dictionary<int, string>();
    public HUD_Codigo HUD;
    public GameObject puntoRespawn;
    public GameObject perdigon;
    public GameObject cascote;
    public GameObject dinamita;
    public GameObject HitBoxMelee;
    public GameObject PuntoSpawn;
    public Animator animador;
    public Camera camara;
    public AudioSource boing;
    public AudioSource disparo;
    public AudioSource oww;
    public AudioSource CurarSonido;
    void Start()
    {
        Debug.Log($"{gameObject.name} spawneado");
        inventario.Add(0,"cascote");
        inventario.Add(1,"dinamita");
        inventario.Add(2,"trabuco");
        objetoElegido = inventario[numeroInventario];

        if(objetoElegido == "trabuco")
            {
                animador.SetBool("trabucoSeleccion", true);
                animador.SetBool("cascoteSeleccion", false);
            }
        else
            {
                animador.SetBool("trabucoSeleccion", false);
                animador.SetBool("cascoteSeleccion", true);
            }
        
        HUD.actualizarObjetoSeleccionado(objetoElegido);
        HUD.actualizarVida(Vida);
        HUD.actualizarOro(OroGremloide);
        HUD.actualizarOro(TesorosAgarrados);
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = 0;
        if (Vivo == true)
        {
            comportamientoVivo();
        }

    }

    private void comportamientoVivo()
    {
        if (Input.GetKeyDown(KeyCode.Y) && usandoObjeto == false)
        {
            if(numeroInventario < inventario.Count -1)
            {
                numeroInventario = numeroInventario + 1;
            }
            else
            {
                numeroInventario = 0;
            }

            objetoElegido = inventario[numeroInventario];
            if(objetoElegido == "trabuco")
            {
                animador.SetBool("trabucoSeleccion", true);
                animador.SetBool("cascoteSeleccion", false);
            }
            else
            {
                animador.SetBool("trabucoSeleccion", false);
                animador.SetBool("cascoteSeleccion", true);
            }
            HUD.actualizarObjetoSeleccionado(objetoElegido);
        }



        if (Input.GetKeyDown(KeyCode.F) && usandoObjeto == false)
        {
            usandoPico = true;
        }
        if (Input.GetKeyDown(KeyCode.G) &&  usandoPico == false)
        {
            usandoObjeto = true;
        }

       if(usandoPico == true)
        {   Input.ResetInputAxes();
            animador.SetBool("Minando", true);
        }
        else
        {
            animador.SetBool("Minando", false);
        }

        if(usandoObjeto == true)
        {   Input.ResetInputAxes();
            animador.SetBool("Disparando", true);

        }
        else
        {
            animador.SetBool("Disparando", false);
        }

        if(Input.GetAxis("Horizontal") != 0)
        {
            animador.SetBool("Moviendose", true);
        }
        else
        {
            animador.SetBool("Moviendose", false);
        }
        
        


        if (Input.GetKeyDown(KeyCode.Space) && estaEnElSuelo == true)
        {
            Debug.Log($"Apretaste la barra");
            boing.Play();
            velocity.y  = 0.01f;
            cuerpo.linearVelocityY = velocity.y * multiplicadorSalto;
            estaEnElSuelo = false;
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            velocity.x = -0.01f;
            imagen.flipX = true;

            Vector3 puntoTemp = transform.position;
            puntoTemp.x = transform.position.x -1;
            PuntoSpawn.transform.position = puntoTemp;

            Vector3 puntoHitboxTemp = transform.position;
            puntoHitboxTemp.x = transform.position.x -0.7f;
            HitBoxMelee.transform.position = puntoHitboxTemp;

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            velocity.x  = 0.01f;
            imagen.flipX = false;

            Vector3 puntoTemp = transform.position;
            puntoTemp.x = transform.position.x + 1;
            PuntoSpawn.transform.position = puntoTemp;

            Vector3 puntoHitboxTemp = transform.position;
            puntoHitboxTemp.x = transform.position.x + 0.7f;
            HitBoxMelee.transform.position = puntoHitboxTemp;
        }


    /*
        if(Vida <= 0)
        {
        Morir();
        }
*/
    }
    public void FinAnimacion()
    {
        usandoPico = false;
        usandoObjeto = false;
        Debug.Log("se acabo la animacion");
    }

    public void AtaqueProyectil()
    {
        if(objetoElegido == "cascote")
        {
          AtaqueProyectilCascote();
        }
        else if(objetoElegido == "trabuco")
        {
            AtaqueProyectilTrabuco();
        }
        else if(objetoElegido == "dinamita"){
            AtaqueProyectilDinamita();
            
        }
        

    }
    public void AtaqueProyectilDinamita()
    {
        GameObject clonDinamita = Instantiate(dinamita, PuntoSpawn.transform.position, Quaternion.identity);
    }
    public void AtaqueProyectilCascote()
    {
        GameObject clone = Instantiate(cascote, PuntoSpawn.transform.position, Quaternion.identity);
        if(imagen.flipX == false){
        clone.GetComponent<Rigidbody2D>().linearVelocityX = 5;
        }
        else
        {
        clone.GetComponent<Rigidbody2D>().linearVelocityX = -5;
        }
    }
    public void AtaqueProyectilTrabuco()
    {
            if (!disparo.isPlaying)
            {
                disparo.Play();
            }
        GameObject clone = Instantiate(perdigon, PuntoSpawn.transform.position, Quaternion.identity);
        GameObject clone2 = Instantiate(perdigon, PuntoSpawn.transform.position, Quaternion.identity);
        GameObject clone3 = Instantiate(perdigon, PuntoSpawn.transform.position, Quaternion.identity);
        clone.GetComponent<ComportamientoObjetoBase>().StartCoroutine("EmpezarConteoBorrar");
        clone2.GetComponent<ComportamientoObjetoBase>().StartCoroutine("EmpezarConteoBorrar");
        clone3.GetComponent<ComportamientoObjetoBase>().StartCoroutine("EmpezarConteoBorrar");
        if(imagen.flipX == false){
        clone.GetComponent<Rigidbody2D>().linearVelocityX = 20;
        
        clone2.GetComponent<Rigidbody2D>().linearVelocityX = 20;
        clone3.GetComponent<Rigidbody2D>().linearVelocityX = 20;
        }
        else
        {
        clone.GetComponent<Rigidbody2D>().linearVelocityX = -20;

        clone2.GetComponent<Rigidbody2D>().linearVelocityX = -20;
        clone3.GetComponent<Rigidbody2D>().linearVelocityX = -20;
        }
        clone2.GetComponent<Rigidbody2D>().linearVelocityY = 2;
        clone3.GetComponent<Rigidbody2D>().linearVelocityY = -2;
        
    }
    public void AtaqueCercano()
    {/*
        Vector2 direccion = (PuntoSpawn.transform.position -transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position,direccion);
        if (hit.collider.gameObject.CompareTag("Criatura"))
        {
            Destroy(hit.collider.gameObject);
           //Debug.Log("COLISION DETECTADA");
           //hit.collider.GetComponent<TerrenoDestruible>().detectarGolpe(new Vector3(hit.point.x,hit.point.y,0));
        }
       */
       HitBoxMelee.SetActive(true);
       StartCoroutine("TemporizadorDesabilitar",HitBoxMelee);
       

    }


    private void OnTriggerEnter2D(Collider2D objeto)
    {
        estaEnElSuelo = true;
    /*
        if(objeto.tag == "Terreno")
        estaEnElSuelo = true;
    */
        /*else*/ if(objeto.CompareTag("Trampa"))
        {
            Dañar(2);
            HUD.actualizarVida(Vida);
            if (!oww.isPlaying)
            {
                oww.Play();
            }
        }
        /*
        else if(objeto.CompareTag("ItemSalud"))
        {
            Dañar(-2);
            IndicadorVida.text = "Vida:" + Vida;
            Destroy(objeto.gameObject);
        }
        else if(objeto.CompareTag("Recurso"))
        {
            OroGremloide = OroGremloide + 5;
            IndicadorOroGremloide.text = "Oro:" + OroGremloide;
            Destroy(objeto.gameObject);
        }
*/
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Criatura"))
        {
            Dañar(2);
            HUD.actualizarVida(Vida);
            if (!oww.isPlaying)
            {
                oww.Play();
            }
        }
         else if(collision.collider.CompareTag("ItemSalud"))
        {
            Dañar(-2);
            HUD.actualizarVida(Vida);
            if (!CurarSonido.isPlaying)
            {
                CurarSonido.Play();
            }


            Destroy(collision.collider.gameObject);
        }
        else if(collision.collider.CompareTag("Recurso"))
        {
            OroGremloide = OroGremloide + 5;
            HUD.actualizarOro(OroGremloide);
            Destroy(collision.collider.gameObject);
        }
        else if(collision.collider.CompareTag("TesoroCondicionGanar"))
        {
            TesorosAgarrados = TesorosAgarrados + 1;
            HUD.actualizarTesoro(TesorosAgarrados);
            if(TesorosAgarrados >= 3)
            {
            HUD.GanarPartida();
            }
            Destroy(collision.collider.gameObject);
        }
        else if(collision.collider.CompareTag("Explosion"))
        {
            Dañar(8);
            HUD.actualizarVida(Vida);
            if (!oww.isPlaying)
            {
                oww.Play();
            }
        }
            else if(collision.collider.CompareTag("TerrenoMuerteInstantanea"))
        {
            Dañar(100);
            HUD.actualizarVida(Vida);
            if (!oww.isPlaying)
            {
                oww.Play();
            }
        }

    }

    public override void Morir()
    {
        animador.Play("Morir");
        Vivo = false;
        StartCoroutine("Respawnear");
    }

    void FixedUpdate()
    {
        cuerpo.linearVelocityX = velocity.x * multiplicadorVelocidad;
    }
    public IEnumerator Respawnear()
{   int segundos = 0;
    WaitForSeconds delay = new WaitForSeconds(1f);
    while (true)
    {
        if(segundos > 10)
        {
            transform.position = puntoRespawn.transform.position;
            Vivo = true;
            //Dañar(-10);
            Vida = 10;
            animador.Play("Idle");
            HUD.actualizarVida(Vida);
            StopCoroutine("Respawnear");
        }
        segundos += 1;
        yield return delay;
    }
    }
}
