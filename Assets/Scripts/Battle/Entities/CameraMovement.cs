using UnityEngine;
using Work2.Battle.CompositeRoot;
using Zenject;

namespace Work2.Battle.Entities
{
    public class CameraMovement : MonoBehaviour
    {
        private Transform _playerTransform;

        [Inject] private void Construct(IPlayer player)
        {
            _playerTransform = player.PositionInfo();
        }

        private void LateUpdate()
        {
            var cameraPosition = transform.position;
            transform.position = new Vector3(cameraPosition.x, _playerTransform.position.y);
        }
    }
}
