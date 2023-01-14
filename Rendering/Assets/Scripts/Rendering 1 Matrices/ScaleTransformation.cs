using UnityEngine;

namespace Assets.Scripts.Rendering_1_Matrices
{
    internal class ScaleTransformation : Transformation
    {
        [SerializeField] private Vector3 _scale;

        public override Matrix4x4 Matrix
        {
            get
            {
                var matrix = new Matrix4x4();
                matrix.SetRow(0, new Vector4(_scale.x, 0, 0, 0));
                matrix.SetRow(1, new Vector4(0, _scale.y, 0, 0));
                matrix.SetRow(2, new Vector4(0, 0, _scale.z, 0));
                matrix.SetRow(3, new Vector4(0, 0, 0, 1));
                return matrix;
            }
        }
    }
}