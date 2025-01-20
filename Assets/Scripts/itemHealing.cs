using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHealing : MonoBehaviour
{
    [SerializeField] private int life;
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
            sistemaVidas.AumentarVida(life);
            Destroy(gameObject);
        }
    }
      
}
