using System;
using UnityEngine;
using Utils;
using Zenject;

namespace Models
{
    [Serializable]
    public class PlayerModel : IInitializable
    {
        [SerializeField] private int _level;
        public int Level => _level;
        
        public void Initialize()
        {
            
        }
    }
}