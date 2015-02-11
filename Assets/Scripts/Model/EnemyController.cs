using UnityEngine;
using System.Collections;

public class EnemyController : CharactersController 
{
    protected override void AfterStart()
    {
        base.AfterStart();

    }
    void OnTriggerEnter2D(Collider2D c)
    {
        _newDirection = -_direction;
    }
}
