using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chamaleon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bolafuego;
    [SerializeField] private Transform puntoSpawn;
    [SerializeField] private float tiempoAtaques;
    [SerializeField] private int danoAtaque;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("RutinaAtaque");
    }
    IEnumerator RutinaAtaque()
    {
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(tiempoAtaques);
    
    }
    private void LanzarBola()
    {
        Debug.Log("Lanza bola");
        Instantiate(bolafuego, puntoSpawn.position, transform.rotation);
    }
}
