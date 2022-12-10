using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour, Enemy
{
    [SerializeField]
    private float health = 100f;

    [SerializeField]
    private float speed = 2f;

    private Rigidbody2D rigidbody;

    private Transform playerTransform;

    private IEnemyLogic enemyLogic;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        enemyLogic = new GhostEnemyLogic(transform, playerTransform, rigidbody);
    }

    // Update is called once per frame
    void Update()
    {
        enemyLogic.setSpeed(speed);
    }


    private void LateUpdate()
    {
        enemyLogic.Movement();
    }


}
