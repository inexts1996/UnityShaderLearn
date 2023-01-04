using UnityEngine;

namespace Assets.Scripts.Rendering_1_Matrices
{
    internal class RotationTransformation : Transformation
    {
        [SerializeField] private Vector3 _rotation;

        public override Vector3 Apply(Vector3 point)
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

            var pointTemp = point;
            Vector3 xAxis = new Vector3(cosX * cosZ, cosX * sinZ + sinX * sinY * cosZ,
                sinX * sinZ - cosX * sinY * cosZ);
            Vector3 yAxis = new Vector3(-cosY*sinZ, cosX*cosZ-sinX*sinY*sinZ, sinX*cosZ+cosX*sinY*sinZ);
            Vector3 zAxis = new Vector3(sinY, -sinX*cosY, cosX*cosY);
            pointTemp = point.x * xAxis + point.y * yAxis + point.z * zAxis; 
            return pointTemp;
        }
    }
}