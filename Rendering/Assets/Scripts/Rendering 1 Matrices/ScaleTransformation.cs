using UnityEngine;

namespace Assets.Scripts.Rendering_1_Matrices
{
    internal class ScaleTransformation : Transformation
    {
        [SerializeField] private Vector3 _scale;
        public override Vector3 Apply(Vector3 point)
        {
            var pointTemp = point;
            pointTemp.x *= _scale.x;
            pointTemp.y *= _scale.y;
            pointTemp.z *= _scale.z;
            return pointTemp;
        }
    }
}
