using UnityEngine;
using System.Collections;

public class PacmanController : CharactersController 
{
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == EnemyTag && GameManager.ChangeLifes != null) GameManager.ChangeLifes(-1); // съели
    }
}
