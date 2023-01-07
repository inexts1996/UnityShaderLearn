﻿using UnityEngine;

namespace Assets.Scripts.Rendering_1_Matrices
{
    internal class CameraTransformation : Transformation
    {
        public override Matrix4x4 Matrix
        {
            get
            {
                var matrix = new Matrix4x4();
                matrix.SetRow(0, new Vector4(1, 0, 0, 0));
                matrix.SetRow(1, new Vector4(0, 1, 0, 0));
                matrix.SetRow(2, new Vector4(0, 0, 0, 0));
                matrix.SetRow(3, new Vector4(0, 0, 0, 1));
                return matrix;
            }
        }
    }
}