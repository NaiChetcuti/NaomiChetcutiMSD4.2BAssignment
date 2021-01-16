using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int Wave1damage = 1;
    [SerializeField] int Wave2damage = 2;
    [SerializeField] int Wave3damage = 3;
    [SerializeField] int Wave4damage = 4;
    [SerializeField] int Wave5damage = 5;
    [SerializeField] int Bulletsdamage = 1;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;

    [SerializeField] AudioClip ObstacleDeathSound;

    [SerializeField] [Range(0, 1)] float ObstacleDeathSoundVolume = 0.75f;

    [SerializeField] float health = 50;




    public int GetDamageForWaves()
    {
        return Wave1damage;
        return Wave2damage;
        return Wave3damage;
        return Wave4damage;
        return Wave5damage;
        return Bulletsdamage;

    }


    public void Hit()
    {
        Destroy(gameObject);
    }

    private void Die()
    {
        Destroy(gameObject);

       
    }

    private void ProcessHit(DamageDealer dmg)
    {
        health -= dmg.GetDamageForWaves();


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
