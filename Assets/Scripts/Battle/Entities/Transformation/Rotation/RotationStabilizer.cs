using UnityEngine;

namespace Work2.Battle.Entities.Rotation
{
    public class RotationStabilizer : MonoBehaviour
    {
        private Quaternion _rotation; 
        private Vector3 _positionOffset;

        void Awake()
        {
            _rotation = transform.parent.rotation;
            _positionOffset = transform.localPosition;
        }
        void LateUpdate()
        {
            transform.rotation = _rotation;
            transform.position = transform.parent.position + Vector3.up * 0.5f;
        }
    }
}
