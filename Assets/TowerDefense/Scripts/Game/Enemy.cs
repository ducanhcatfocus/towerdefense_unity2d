using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum EEnemy
{
    Normal,
    Boss,
}

public class Enemy : MonoBehaviour
{
    public static int id = 0;
    public int Identity;
    public EnemySO enemySO;
    public MoveComponent movement;
    public HealthComponent health;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        Identity = id++;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetData(EnemySO data)
    {
        this.enemySO = data;
    }
    public void Init()
    {
        health.SetHp(enemySO.Hp);
        movement.Set(enemySO.Speed);
        int randomIndex = Random.Range(0, enemySO.Sprites.Count -1);
        Debug.Log(randomIndex);
        spriteRenderer.sprite = enemySO.Sprites[randomIndex];
    }

    public void TakeDamage(float dmg)
    {
        health.TakeDamage(dmg);

        // spawn eff
        ParticleSystem bloodResource = Resources.Load<ParticleSystem>("BloodParticlePrefab");
        if (bloodResource != null)
        {
            ParticleSystem bloodIns = Instantiate(bloodResource);
            bloodIns.transform.position = transform.position;
            bloodIns.Play();

            Destroy(bloodIns.gameObject, 2);
        }
    }

    public float GetDmg()
    {
        return enemySO.Dmg;
    }
}
