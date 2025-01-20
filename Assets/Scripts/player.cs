using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputH;
    [Header("SISTEMA DE MOVIMIENTO")]
    [SerializeField] private Transform pies;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float fuerzaSato;
    [SerializeField] private float distanciaDeteccionSuelo;
    [SerializeField] private LayerMask queEsSaltable;
    [SerializeField] private LayerMask queEsDanable;
    private Animator anim;
    [SerializeField] private Transform puntoDeteccion;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask queEsInteractuable;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

      
        
        Saltar();

        Interactuar();
    }

  

    private void Movimiento()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputH * velocidadMovimiento, rb.velocity.y);
        if (inputH != 0)
        {
            anim.SetBool("Running", true);
            if (inputH>0)
            {

                transform.eulerAngles = Vector3.zero;
            }
            else
            {
                transform.eulerAngles = new Vector3(0,180,0);
            }

        }
        else
        {
            anim.SetBool("Running", false);
        }
        
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estoyEnSuelo())
        {
            rb.AddForce(Vector2.up * fuerzaSato, ForceMode2D.Impulse);
            anim.SetTrigger("Saltar");
        }
    }
    private bool estoyEnSuelo()
    {
        bool tocado = Physics2D.Raycast(pies.position, Vector3.down, distanciaDeteccionSuelo, queEsSaltable);
        return tocado;


    }
    private void Interactuar()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            Collider2D collDetectado = Physics2D.OverlapCircle(puntoDeteccion.position, radioDeteccion, queEsInteractuable);
            if(collDetectado != null)
            {
                Debug.Log("interactuo");
            }
        }
    }
  

}
