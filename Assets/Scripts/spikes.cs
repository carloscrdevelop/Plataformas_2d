using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    [SerializeField] private int danoAtaque;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
            SistemaVidas sistemaVidas = collision.gameObject.GetComponent<SistemaVidas>();
            sistemaVidas.RecibirDano(danoAtaque);

        }
    }
}
