using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class FireProjectile : MonoBehaviour
{
    public GameManager manager;
    public GameObject projectile;
    public Transform spawnTransform;
    public float force;
    private StarterAssetsInputs inputs;
    private float time;
    private bool oldswitch;

    public bool pistol = true;

    private IDictionary<string, float> pistolStats = new Dictionary<string, float>();
    private IDictionary<string, float> shotgunStats = new Dictionary<string, float>();
    //code from tutorial
    void Start()
    {

        pistolStats.Add("ROF", 0.3f);
        pistolStats.Add("Burst",1f);
        pistolStats.Add("Damage", 20f);
        pistolStats.Add("Spread", 1f);
        pistolStats.Add("LifeTime", 2f);

        shotgunStats.Add("ROF", 0.75f);
        shotgunStats.Add("Burst", 10f);
        shotgunStats.Add("Damage", 10f);
        shotgunStats.Add("Spread", 10f);
        shotgunStats.Add("LifeTime", 0.5f);


        inputs = GetComponent<StarterAssetsInputs>();

    }

    // Update is called once per frame
    void Update()
    {   

        if (oldswitch!=inputs.switchGun && inputs.switchGun)
        {
            pistol = !pistol;
        }
        oldswitch = inputs.switchGun;
        time += Time.deltaTime;
        if (inputs.fire && manager.gameState == GameManager.GameState.Playing)
        {
            float burst;
            float spread;
            float damage;
            float ROF;
            float lifeTime;
            if (pistol)
            {
                pistolStats.TryGetValue("Spread", out spread);
                pistolStats.TryGetValue("Burst", out burst);
                pistolStats.TryGetValue("Damage", out damage);
                pistolStats.TryGetValue("ROF", out ROF);
                pistolStats.TryGetValue("LifeTime", out lifeTime);
            }
            else
            {
                shotgunStats.TryGetValue("Spread", out spread);
                shotgunStats.TryGetValue("Burst", out burst);
                shotgunStats.TryGetValue("Damage", out damage);
                shotgunStats.TryGetValue("ROF", out ROF);
                shotgunStats.TryGetValue("LifeTime", out lifeTime);
            }
            if (time > ROF)
            {
                time = 0;
                for (int i = 0; i < burst; i++)
                {
                    float spreadX = Random.Range(-spread, spread);
                    float spreadY = Random.Range(-spread, spread);
                    float spreadZ = Random.Range(-spread, spread);
                    GameObject temp = Instantiate(projectile, spawnTransform.position, spawnTransform.rotation);
                    temp.transform.Rotate(spreadX, spreadY, spreadZ);
                    temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward * force);
                    temp.GetComponent<HandleProjectile>().damage = damage;
                    temp.GetComponent<HandleProjectile>().projectileLife = lifeTime;
                    inputs.fire = false;
                }
            }
        }
    }
}
