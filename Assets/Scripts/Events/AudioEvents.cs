using UnityEngine.Events;

namespace Events
{
    public class AudioEvents
    {
        public  UnityAction<float> VolumeChanged;
        public  UnityAction ButtonClicked;
        public  UnityAction TileDestroyed;
        public  UnityAction TileSlided;
        public  UnityAction TileBombed;
    }
}