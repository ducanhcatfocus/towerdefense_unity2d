using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemySO : ScriptableObject
{
    public float Speed;
    public float Hp;
    public float Dmg;
    public EEnemy EnemyType;
    public List<Sprite> Sprites;
}
