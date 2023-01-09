using UnityEngine;

namespace Assets.Scripts.Rendering_1_Matrices
{
    internal class CameraTransformation : Transformation
    {
        [SerializeField] private float _focalLength = 1.0f;
        public override Matrix4x4 Matrix
        {
            get
            {
                var matrix = new Matrix4x4();
                matrix.SetRow(0, new Vector4(_focalLength, 0, 0, 0));
                matrix.SetRow(1, new Vector4(0, _focalLength, 0, 0));
                matrix.SetRow(2, new Vector4(0, 0, 0, 0));
                matrix.SetRow(3, new Vector4(0, 0, 1, 0));
                return matrix;
            }
        }
    }
}