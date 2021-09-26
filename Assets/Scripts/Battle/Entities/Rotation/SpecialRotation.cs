using System;
using System.Collections;
using UnityEngine;

namespace Work2.Battle.Entities
{
    public class SpecialRotation : MonoBehaviour
    {
        public Quaternion RotationToTarget2D(Vector2 localTarget)
        {
            float angle = Mathf.Atan2(localTarget.y, localTarget.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public void RotateToTarget2D(Vector2 localTarget)
        {
            transform.rotation = RotationToTarget2D(localTarget);
        }

        /// <param name="speed">Seconds per movement tick</param>
        public IEnumerator SlowlyRotationCoroutine(Vector2 localTarget, int speed, Action callback = null, float delayAfterRotation = 0.3f)
        {
            if (speed < 0)
                throw new ArgumentOutOfRangeException(nameof(speed));

            var from = transform.rotation;
            var targetQuaternion = RotationToTarget2D(localTarget);
            var rotationStep = FractedBySpeedAngle(from, targetQuaternion, speed);

            for (int i = 0; i < speed; i++)
            {
                transform.rotation = Quaternion.RotateTowards(from, targetQuaternion, rotationStep);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(delayAfterRotation);
            callback?.Invoke();
        }

        private float FractedBySpeedAngle(Quaternion from, Quaternion to, int speed)
        {
            var targetRotation = to.z;
            var currentRotation = from.z;
            var minimalAngle = Math.Min(targetRotation, currentRotation);
            var rotationDelta = Math.Max(targetRotation, currentRotation) - minimalAngle;
            return rotationDelta / speed;
        }
    }
}
