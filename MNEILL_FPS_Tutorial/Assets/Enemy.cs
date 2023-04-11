using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent navAgent;
    public GameManager gameManager;
    public GameObject warning;
    public float health = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(player.transform.position);//for navigation towards player

        //from tutorial https://www.youtube.com/watch?v=BC3AKOQUx04&t=890s&ab_channel=WatchFindDoMedia
        Vector3 direction = transform.position - player.transform.position;
        Quaternion tRot = Quaternion.LookRotation(direction);
        tRot.z = -tRot.y;
        tRot.y = 0;
        tRot.x = 0;

        Vector3 forward = new Vector3(0,0,player.transform.eulerAngles.y);
        warning.transform.localRotation = tRot * Quaternion.Euler(forward);
        //end tutorial

        warning.GetComponent<Image>().color = new Color(1,1,1, 1-(Vector3.Distance(transform.position, player.transform.position)/25));//adjust alpha of warning image depending on distance away from player
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            gameManager.gameState = GameManager.GameState.GameOver;//end game if player is hit
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;//if hit by projectile, take damage
        if (health <= 0)
        {
            Destroy(gameObject);//if health is lower than 0, delete game object.
        }
    }
}
