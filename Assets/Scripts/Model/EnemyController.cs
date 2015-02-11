using UnityEngine;
using System.Collections;

public class EnemyController : CharactersController 
{
    public float Seconds;
    protected override void AfterStart()
    {
        base.AfterStart();
        StartCoroutine(RandomRun());
    }

    IEnumerator RandomRun()
    {
        Vector2 direction = Vector2.right;
        while(Application.isPlaying)
        {
            yield return new WaitForSeconds(Seconds);
            int d = Random.Range(0, 4);

            switch (d)
            {
                case 0: direction = Vector2.right; break;
                case 1: direction = Vector2.up; break;
                case 2: direction = -Vector2.right; break;
                case 3: direction = -Vector2.up; break;
                default: break;
            }
            SetDirection(direction);
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        _newDirection = -_direction;
    }
}
