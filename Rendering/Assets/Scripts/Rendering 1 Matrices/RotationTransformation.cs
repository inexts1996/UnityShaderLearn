using UnityEngine;

namespace Assets.Scripts.Rendering_1_Matrices
{
    internal class RotationTransformation : Transformation
    {
        [SerializeField] private Vector3 _rotation;

        public override Matrix4x4 Matrix
        {
            get
            {
                float radX = _rotation.x * Mathf.Deg2Rad;
                float sinX = Mathf.Sin(radX);
                float cosX = Mathf.Cos(radX);

                float radY = _rotation.y * Mathf.Deg2Rad;
                float sinY = Mathf.Sin(radY);
                float cosY = Mathf.Cos(radY);
                float radZ = _rotation.z * Mathf.Deg2Rad;
                float sinZ = Mathf.Sin(radZ);
                float cosZ = Mathf.Cos(radZ);

                // Vector3 xAxis = new Vector3(cosX * cosZ, cosX * sinZ + sinX * sinY * cosZ,
                    // sinX * sinZ - cosX * sinY * cosZ);
                // Vector3 yAxis = new Vector3(-cosY * sinZ, cosX * cosZ - sinX * sinY * sinZ,
                    // sinX * cosZ + cosX * sinY * sinZ);
                // Vector3 zAxis = new Vector3(sinY, -sinX * cosY, cosX * cosY);

                var matrix = new Matrix4x4();

                matrix.SetRow(0, new Vector4(cosX * cosZ, -cosY * sinZ, sinY, 1));
                matrix.SetRow(1,
                    new Vector4(cosX * sinZ + sinX * sinY * cosZ, cosX * cosZ - sinX * sinY * sinZ, -sinX * cosY, 1));
                matrix.SetRow(2,
                    new Vector4(sinX * sinZ - cosX * sinY * cosZ, sinX * cosZ + cosX * sinY * sinZ, cosX * cosY, 1));
                matrix.SetRow(3, new Vector4(0, 0, 0, 1));

                return matrix;
            }
        }
        
    }
}