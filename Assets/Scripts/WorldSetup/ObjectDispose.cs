using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDispose : MonoBehaviour
{
    private Transform _player;
    private float maxDistance = 10f;

    private void Awake() {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update() {
        float distance = Vector3.Distance(transform.position, _player.position);
        if(distance > maxDistance){
            Destroy(gameObject);
        }
    }

}
