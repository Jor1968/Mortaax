using UnityEngine;

public class ComportamientoCriaturaVoladora : ComportamientoObjetoBase
{
    public GameObject objetoLoot;
    public GameObject CasaSpawn;
    public Animator animador;
    public float velocidad;
    public Transform JugadorPosicion;
    public AudioSource oww;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animador.Play("Idle");
        JugadorPosicion = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(JugadorPosicion != null)
        {
            Vector2 direccion = (JugadorPosicion.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position,JugadorPosicion.position,velocidad * Time.deltaTime);
        }
        
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("AtaqueMinar"))
        {
            Dañar(2);
            if (!oww.isPlaying)
            {
                oww.Play();
            }
        }
        else if (collision.collider.CompareTag("Proyectil"))
        {
            Dañar(2);
            if (!oww.isPlaying)
            {
                oww.Play();
            }
        }

    }
        public override void Morir()
    {
        GameObject clone = Instantiate(objetoLoot, transform.position, Quaternion.identity);
        if (CasaSpawn != null)
        {
            CasaSpawn.GetComponent<CreadorDeObjetos>().StartCoroutine("TemporizadorSpawn");
        }
        Destroy(gameObject);

    }
}
