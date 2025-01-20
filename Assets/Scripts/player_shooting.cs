using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float timeBetweenShots;
    private bool canshoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& canshoot) {

            Shoot();
            
        
        
        }
    }
    private void Shoot()
    {
        Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(shootDelay());

    }
    IEnumerator shootDelay()
    {
        canshoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canshoot = true;

    }
}
