using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable
{
    void Kill();
}

public interface IDamageable<T>
{
    void Damage(T damageTaken);
}

public interface IEnemy
{
    void Move();
}