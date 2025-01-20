using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float impulsoDisparo;
    [SerializeField] private int danoAtaque;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * impulsoDisparo, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
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
