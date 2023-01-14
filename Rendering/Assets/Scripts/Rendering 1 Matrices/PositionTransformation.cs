using UnityEngine;

namespace Assets.Scripts.Rendering_1_Matrices
{
    public class PositionTransformation : Transformation
    {
        [SerializeField] private Vector3 _offsetPosition;

        public override Matrix4x4 Matrix
        {
            get
            {
                var matrix = new Matrix4x4();
                matrix.SetRow(0, new Vector4(1, 0, 0, _offsetPosition.x));
                matrix.SetRow(1, new Vector4(0, 1, 0, _offsetPosition.y));
                matrix.SetRow(2, new Vector4(0, 0, 1, _offsetPosition.z));
                matrix.SetRow(3, new Vector4(0, 0, 0, 1));

                return matrix;
            }
        }
    }
}