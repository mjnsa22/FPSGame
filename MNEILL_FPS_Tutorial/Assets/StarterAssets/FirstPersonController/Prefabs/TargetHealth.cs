using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealth : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1f, (currentHealth / maxHealth), (currentHealth / maxHealth), 1f));//adjust color to show how much health is left

    }

    private void TargetDestroy()
    {
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))//if a projectile hits the target
        {
            currentHealth -= collision.gameObject.GetComponent<HandleProjectile>().damage;//take the damage
            if (currentHealth <= 0)
            {
                TargetDestroy();//if health is less then 0 destroy gameobject
            }
        }
    }
}
