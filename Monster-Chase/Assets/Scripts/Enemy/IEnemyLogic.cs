using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemyLogic
{
    void Movement();

    void DamagePlayerHealth();

    void GetKilled();

    void setSpeed(float speed);
}