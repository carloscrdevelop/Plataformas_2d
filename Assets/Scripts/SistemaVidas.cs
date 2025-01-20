using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVidas : MonoBehaviour
{
    [SerializeField] public int vidas;
    public Healthbar healthbar;
    public int maxHealth = 100;
    [SerializeField] private float inmortalTime=2f;
    [SerializeField] private float inmortalCounter;
    [SerializeField] private int cantidadVida;

    public void RecibirDano(int danoRecibido)
    {
        if (inmortalCounter <= 0) 
        {
            vidas -= danoRecibido;
            healthbar.SetHealth(vidas);
            Debug.Log(vidas);
            if (vidas < 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                inmortalCounter = inmortalTime;
            }

        }

   

    }

    public void AumentarVida(int vidaRecibida)
    {

        vidas += vidaRecibida;
        
            if (vidas >= 100)
            {
                vidas = 100;

            }
            healthbar.SetHealth(vidas);
        
        


    }
    void Start()
    {
        vidas = maxHealth;
        healthbar.SetMaxHealth(vidas);
    }

    // Update is called once per frame
    void Update()
    {
        if(inmortalCounter>0)
        {
            inmortalCounter -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="inmortal")
        {

            inmortalCounter = inmortalTime;
            Destroy(collision.gameObject);
        }
      
    }
   
}
