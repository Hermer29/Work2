using UnityEngine;

namespace Work2.Battle.CompositeRoot.Helpers
{
    public class Player : IPlayer
    {
        private GameObject _object;
        private Transform _transform;

        public Player(GameObject @object)
        {
            _object = @object;
            _transform = _object.transform;
        }

        public Transform PositionInfo()
        {
            return _transform;
        }
    }
}
