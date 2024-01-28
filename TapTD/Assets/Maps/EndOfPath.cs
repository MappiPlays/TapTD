using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfPath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
            enemy.OnReachedEnd();
    }
}
