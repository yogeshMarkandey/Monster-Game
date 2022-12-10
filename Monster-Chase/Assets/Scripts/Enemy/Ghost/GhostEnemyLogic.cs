using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostEnemyLogic : IEnemyLogic
{
    private Transform playerTransform;
    private Transform enemyTransform;

    [HideInInspector]
    public float speed = 2f;

    private Rigidbody2D rigidBody;

    public GhostEnemyLogic(Transform enemyTransform, Transform playerTransfrom, Rigidbody2D enemyRigidBody)
    {
        this.enemyTransform = enemyTransform;
        rigidBody = enemyRigidBody;
        this.playerTransform = playerTransfrom;
    }

    // IEnemyLogic Implementation
    public void DamagePlayerHealth()
    {
        throw new System.NotImplementedException();
    }

    public void GetKilled()
    {
        throw new System.NotImplementedException();
    }

    public void Movement()
    {
        if (!playerTransform)
            return;

        if (!enemyTransform)
            return;

        if (!rigidBody)
            return;

        Vector3 playerPos = playerTransform.position;
        Vector3 enemyPos = enemyTransform.position;

        if(playerPos.x > enemyPos.x && playerPos.x - enemyPos.x > 1)
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
            enemyTransform.localScale = new Vector3(1f, 1f, 1f);
            return;
        }
        
        if(playerPos.x < enemyPos.x && enemyPos.x - playerPos.x > 1)
        {
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
            enemyTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

}