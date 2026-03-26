using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public GameObject gunHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDead();
    }
    public void Damage(float damage, Quaternion rot)
    {
        AudioManager.instance.PlayEnemyDamage();
        health -= damage;

        GameObject damageEffect = Instantiate(gunHit, transform.position, rot);
        Destroy(damageEffect, 0.5f);
    }

    public void EnemyDead()
    {
        if (health <=0)
        {
            EnemyManager.instance.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }
}
