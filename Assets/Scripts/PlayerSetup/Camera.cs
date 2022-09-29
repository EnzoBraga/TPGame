using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float smoothing;

    private Vector3 playerPos;
    
    private void Awake()
    {
        _player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if(_player != null){
            playerPos = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, playerPos, smoothing);
        }
    }
}