using UnityEngine;

public class ComportamientoCriaturaVoladora : ComportamientoObjetoBase
{
    public GameObject objetoLoot;
    public Animator animador;
    public float velocidad;
    public Transform JugadorPosicion;
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

        }
        else if (collision.collider.CompareTag("Proyectil"))
        {
            Dañar(2);
        }
    }
        public override void Morir()
    {
        GameObject clone = Instantiate(objetoLoot, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
