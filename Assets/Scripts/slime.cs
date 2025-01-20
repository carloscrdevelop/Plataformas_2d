using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float velocidadPatrulla;
    [SerializeField] private int danoAtaque;
    private Vector3 destinoActual;
    private int indiceActual;
    void Start()
    {
        destinoActual = waypoints[indiceActual].position;
        StartCoroutine(Patrulla());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Patrulla()
    {
        while (true) { 
            while (transform.position != destinoActual)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinoActual, velocidadPatrulla * Time.deltaTime);
                yield return null;
            }
            definirnuevodestino();
        }

    }
    private void definirnuevodestino()
    {
        indiceActual++;
        if (indiceActual >= waypoints.Length)
        { 
            indiceActual = 0;
        }
        destinoActual = waypoints[indiceActual].position;
        enfocarDestino();

    }
    private void enfocarDestino()
    {
        if(destinoActual.x> transform.position.x)
        {
            transform.localScale = Vector3.one;

        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeteccionPlayer"))
        {
            
        
        }
        else if (collision.gameObject.CompareTag("PlayerHitBox"))
        {

            SistemaVidas sistemaVidas = collision.gameObject.GetComponent<SistemaVidas>();
            sistemaVidas.RecibirDano(danoAtaque);
        }
    }
}
