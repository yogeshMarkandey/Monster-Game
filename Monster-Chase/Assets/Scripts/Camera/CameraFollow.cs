using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private const string PLAYER_TAG = "Player";
    private Transform playerTransform;

    [SerializeField]
    private float minX;

    [SerializeField]
    private float maxX;

    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {

        if (!playerTransform)
            return;

        tempPos = transform.position;
        tempPos.x = playerTransform.position.x;

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;
    }
}
