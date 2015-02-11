using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public string WallsTag = "Wall";
    public Vector2 CenterDelta = Vector2.zero;

    const int dimx = 20; // поле 20х20
    const int dimy = 20;
    float _gridStep = 0.364211f; // абсолютные 0,0 в [9,9]
    bool[,] _obstacles = new bool[dimx, dimy];
    Vector2[,] _positions = new Vector2[dimx, dimy];

    public static LevelManager Instance;

    void Awake()
    {
        if (Instance != null) Debug.LogError("Should be only one level manager!");
        Instance = this;

        for (var i = 0; i < dimx; i++)
            for (var j = 0; j < dimy; j++)
            {
                var x = (i - 9) * _gridStep;// -CenterDelta.x;
                var y = (j - 9) * _gridStep;// -CenterDelta.y;
                _positions[i, j] = new Vector2(x, y);
                _obstacles[i, j] = false;
            }

        var walls = GameObject.FindGameObjectsWithTag(WallsTag);
        if (walls == null) Debug.LogError("No walls found!");
        foreach (var wall in walls)
        {
            var x = wall.transform.position.x;// -CenterDelta.x;
            var y = wall.transform.position.y;// -CenterDelta.y;
            var i = Mathf.RoundToInt(x / _gridStep + ((dimx / 2f) - 1f));
            var j = Mathf.RoundToInt(y / _gridStep + ((dimy / 2f) - 1f));

            _obstacles[i, j] = true;
        }
    }

    void Update()
    {
    }

    public Vector2 NextStop(Vector2 from, Vector2 to)
    {
        var x = from.x;
        var y = from.y;

        var i = Mathf.RoundToInt(x / _gridStep + ((dimx / 2) - 1));
        var j = Mathf.RoundToInt(y / _gridStep + ((dimy / 2) - 1));

        if (i < 0) i = 0;
        if (i > dimx - 1) i = dimx - 1;
        if (j < 0) j = 0;
        if (j > dimy - 1) j = dimy - 1;

        var up = Mathf.RoundToInt(to.y);
        var right = Mathf.RoundToInt(to.x);

        if (((j + up) < dimy) && ((j + up) > -1) && ((i + right) < dimx) && ((i + right) > -1) && !_obstacles[i + right, j + up])
        {
            i += right;
            j += up;
        }
        return _positions[i, j];
    }
}
