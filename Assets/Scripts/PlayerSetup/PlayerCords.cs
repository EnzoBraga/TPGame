using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCords : MonoBehaviour
{
    public static PlayerCords instance;

    private void Awake() {
        instance = this;
    }

    public Transform playerTransform;
}
