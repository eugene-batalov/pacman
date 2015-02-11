using UnityEngine;
using System.Collections;

public class CharactersController : MonoBehaviour {

    public float Speed = 1f;
    public float _delta = 0.1f; // для проверки нахождения у поворота

    public string EnemyTag = "Enemy";

    protected Vector2 _direction;
    protected Vector2 _newDirection;

    protected Vector2 _from;
    protected Vector2 _to;
    protected Vector2 _oldPosition;
    protected bool _pause;

    protected void Start()
    {
        _oldPosition = _to = _from = transform.position;
        _newDirection = _direction = Vector2.zero;
        GameManager.PauseOnOff += (p) => _pause = p;
        AfterStart();
    }

    protected virtual void AfterStart()
    { 
    }

    protected bool CanMove()
    {
        if ((_direction != Vector2.zero || _newDirection != _direction) && !_pause)
        {
            _to = LevelManager.Instance.NextStop(transform.position, _newDirection);
        }
        else return false;

        if (Vector2.Dot(_newDirection, _to - (Vector2)transform.position) > 0f) // есть куда двигаться
        {
            if (_to != _oldPosition)
            {
                _from = _oldPosition;
                _oldPosition = _to;
            }
            _direction = _newDirection;

            if (Mathf.Abs(_direction.y) > 0.9) transform.position = new Vector2(_to.x, transform.position.y); // корректировка при движении вверх или вниз
            if (Mathf.Abs(_direction.x) > 0.9) transform.position = new Vector2(transform.position.x, _to.y); // вправо или влево

            return true;
        }
        else
        {
            _direction = _newDirection = Vector2.zero;
            return false;
        }
    }

    protected void Move()
    {
        rigidbody2D.isKinematic = true;

        transform.Translate(Time.deltaTime * _direction * Speed);
        rigidbody2D.isKinematic = false;
    }

    protected void Update()
    {
        if (CanMove()) Move();
    }

    public void SetDirection(Vector2 d)
    {
        if (Vector2.Dot(_direction, d) == -1f || _direction == Vector2.zero) // развернуться назад или тронуться
        {
            _newDirection = d;
            Swap();
            return;
        }

        var to = Vector3.Magnitude((Vector2)transform.position - _to);
        var from = Vector3.Magnitude((Vector2)transform.position - _from);

        if (to < _delta || from < _delta) // если близко к перекрестку, попробовать повернуть
        {
            _newDirection = d;
        }
    }

    protected void Swap()
    {
        var temp = _to;
        _to = _from;
        _from = temp;
    }
}
