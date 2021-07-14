using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("cat");
    }

    void Update()
    {
        Vector3 PlayerPos = Player.transform.position;
        transform.position = new Vector3(
            transform.position.x, PlayerPos.y, transform.position.z);
    }
}
