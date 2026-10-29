using UnityEngine;

public class ComportamientoCriaturaVoladora : ComportamientoObjetoBase
{
    public GameObject objetoLoot;
    public Animator animador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animador.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        
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
