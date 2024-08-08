using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GridEvents
    {
        public UnityAction<Bounds> GridLoaded;
        public UnityAction InputStart;
        public UnityAction InputStop;
        public UnityAction<int> MatchGroupDespawn;
        public UnityAction TotalTimeIncrease;
        public UnityAction BombPowerupTimeIncrease;
        public UnityAction VerticalPowerupTimeIncrease;
        public UnityAction HorizontalPowerupTimeIncrease;
    }
}