using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleProjectile : MonoBehaviour
{
    public float projectileLife;
    private float timer;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > projectileLife)//if the projectile has not hit anything and it has reached the end of its lifespan,
        {
            Destroy(gameObject);// destroy gameobject
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))//if collided with an enemy
        {
            other.gameObject.GetComponent<Enemy>().takeDamage(damage);//take damage from enemy
            Destroy(gameObject);//destroy game object
        }

        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Projectile"))//if the projectile has collided
        {
            Destroy(gameObject);//destroy game object
        }
    }

} 