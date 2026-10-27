using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrenoDestruible : MonoBehaviour
{
    public Tilemap terreno;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void detectarGolpe(Vector3 posicion)
    {
        Debug.Log("Tendria que desaparecer un bloque");
        terreno.WorldToCell(posicion);
        Vector3Int posicionTilemap = terreno.WorldToCell(posicion);
        terreno.SetTile(posicionTilemap, null);
    }
    
      private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("AtaqueMinar"))
        {
            detectarGolpe(collision.contacts[0].point);
        }
    }
    


}
