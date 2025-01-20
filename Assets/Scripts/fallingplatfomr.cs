using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingplatfomr : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float timeToDown,destroyTimeToDown;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="PlayerHitBox")
        {
            StartCoroutine(Fall());
        }
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeToDown);
        rb.bodyType= RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyTimeToDown);

    }
}
