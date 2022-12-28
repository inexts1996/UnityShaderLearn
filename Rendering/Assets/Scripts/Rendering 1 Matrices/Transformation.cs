using UnityEngine;

namespace Assets.Scripts.Rendering_1_Matrices
{
    public abstract class Transformation : MonoBehaviour
    {
        public abstract Vector3 Apply(Vector3 point);
    }
}