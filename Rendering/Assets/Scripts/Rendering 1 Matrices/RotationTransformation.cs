using UnityEngine;

namespace Assets.Scripts.Rendering_1_Matrices
{
    internal class RotationTransformation : Transformation
    {
        [SerializeField] private Vector3 _rotation;

        public override Vector3 Apply(Vector3 point)
        {
            float radZ = _rotation.z * Mathf.Deg2Rad;
            float sinZ = Mathf.Sin(radZ);
            float cosZ = Mathf.Cos(radZ);

            var pointTemp = point;
            pointTemp.x = point.x * cosZ - point.y * sinZ;
            pointTemp.y = point.x * sinZ + point.y * cosZ;

            return pointTemp;
        }
    }
}