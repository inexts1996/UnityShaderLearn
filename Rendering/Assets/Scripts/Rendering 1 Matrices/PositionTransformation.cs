using UnityEngine;

namespace Assets.Scripts.Rendering_1_Matrices
{
    public class PositionTransformation : Transformation
    {
        [SerializeField] private Vector3 _offsetPosition;

        public override Vector3 Apply(Vector3 point)
        {
            return point + _offsetPosition;
        }
    }
}