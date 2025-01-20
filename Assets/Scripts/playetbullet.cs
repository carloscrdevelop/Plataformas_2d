using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playetbullet : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D rb;
    [SerializeField]private int danoAtaque;
    
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, 2f);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right*bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {

            SistemaVidas sistemaVidas = collision.gameObject.GetComponent<SistemaVidas>();
            sistemaVidas.RecibirDano(danoAtaque);
        }
    }
}
