using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField]private float WallMoveSpeed;

    private void Update()
    {
        transform.position += Vector3.left * WallMoveSpeed * Time.deltaTime;
    }
}
