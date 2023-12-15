using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float damage, range;

    public Animator anim;

    GameObject gameObjectHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootGun();
        }

        
    }

    void ShootGun()
    {
        anim.Play("Shoot");

        //print("kek");


        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * hit.distance, Color.red);
           

            //Debug.Log("Did Hit");

            //print("kek hit");

            gameObjectHit = hit.transform.gameObject;

                if(gameObjectHit.TryGetComponent<Enemy>(out Enemy en))
                {
                    en.TakeDamage(damage);
                }
        }
        else
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * range, Color.green);
            
            //Debug.Log("Did not Hit");
        }
    }
}
