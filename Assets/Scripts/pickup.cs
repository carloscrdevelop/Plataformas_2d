using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickup : MonoBehaviour
{
    public int coins = 0;
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Coins: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="coin")
        {
            coins++;
            scoreText.text = "Coins: "+ coins;
            Destroy(collision.gameObject);
        }    
    }
}
