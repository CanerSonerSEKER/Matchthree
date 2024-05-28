using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class Tile : MonoBehaviour
    {
            public Vector2Int Coords => _coords;
            [SerializeField] private Vector2Int _coords;
            [SerializeField] private int _colorID;

            public Tile(Vector2Int coords)
            {
                _coords = coords;
            }

            public void Construct(Vector2Int coords)
            {
                _coords = coords;
            }
    }
}