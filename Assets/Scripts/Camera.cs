using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float smoothing;

    private Vector3 playerPos;
    
    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        playerPos = new Vector3(_player.position.x, _player.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, playerPos, smoothing);
    }
}