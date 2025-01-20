using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estalagtitas : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float timeToDown, destroyTimeToDown;
    [SerializeField] private int danoAtaque;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        /*if (collision.gameObject.CompareTag("DeteccionPlayer"))
        {
            SistemaVidas sistemaVidas = collision.gameObject.GetComponent<SistemaVidas>();
            sistemaVidas.RecibirDano(danoAtaque);

        }*/
        if (collision.gameObject.tag == "PlayerHitBox")
        {
            StartCoroutine(Fall());
        }
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeToDown);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyTimeToDown);

    }
}
