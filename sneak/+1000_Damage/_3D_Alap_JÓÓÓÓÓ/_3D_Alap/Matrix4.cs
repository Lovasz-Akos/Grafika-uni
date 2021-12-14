using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Alap
{
    public class Matrix4
    {
        public float[,] M;

        public Matrix4()
        {
            this.M = new float[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    this[i, j] = 0.0f;
        }

        public Matrix4(Matrix4 matrix)
        {
            this.M = new float[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    this[i, j] = matrix[i, j];
        }

        public float this[int i, int j]
        {
            get { return this.M[i, j]; }
            set { this.M[i, j] = value; }
        }

        public void LoadIdentity()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (i == j) this[i, j] = 1.0f;
                    else this[i, j] = 0.0f;
        }

        //public static Matrix4 operator +(Matrix4 a, Matrix4 b)
        //{
        //    //Hf.:
        //    //Új mátrixot készítünk, és a megfelelő helyen levő elemeket összeadjuk az új helyre
        //}
       
        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            Matrix4 res = new Matrix4();

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    float sum = 0.0f;
                    for (int k = 0; k < 4; k++)
                        sum += a[i, k] * b[k, j];
                    res[i, j] = sum;
                }
            return res;
        }

        public static Vector3 operator *(Matrix4 a, Vector3 v)
        {
            Vector3 res = new Vector3();
            res.x = a[0, 0] * v.x + a[0, 1] * v.y + a[0, 2] * v.z + a[0, 3] * v.w;
            res.y = a[1, 0] * v.x + a[1, 1] * v.y + a[1, 2] * v.z + a[1, 3] * v.w;
            res.z = a[2, 0] * v.x + a[2, 1] * v.y + a[2, 2] * v.z + a[2, 3] * v.w;
            res.w = a[3, 0] * v.x + a[3, 1] * v.y + a[3, 2] * v.z + a[3, 3] * v.w;
            return res;
        }

        #region Projections
        public static Matrix4 Parallel(Vector3 v)
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            res[2, 2] = 0.0f;
            res[0, 2] = -v.x / v.z;
            res[1, 2] = -v.y / v.z;
            return res;
        }
        #endregion

        #region Transformations
        public static Matrix4 RotX(float alpha)
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            res[1, 1] = (float)Math.Cos(alpha);
            res[1, 2] = (float)-Math.Sin(alpha);
            res[2, 1] = (float)Math.Sin(alpha);
            res[2, 2] = (float)Math.Cos(alpha);
            return res;
        }

        public static Matrix4 RotY(float beta)
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            res[0, 0] = (float)Math.Cos(beta);
            res[0, 2] = (float)Math.Sin(beta);
            res[2, 0] = (float)-Math.Sin(beta);
            res[2, 2] = (float)Math.Cos(beta);
            return res;
        }

        public static Matrix4 RotZ(float gamma)
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            res[0, 0] = (float)Math.Cos(gamma);
            res[0, 1] = (float)-Math.Sin(gamma);
            res[1, 0] = (float)Math.Sin(gamma);
            res[1, 1] = (float)Math.Cos(gamma);
            return res;
        }

        public static Matrix4 TransXZ()
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            res[1,1] = -1;
     
            return res;
        }
        public static Matrix4 TransYZ()
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            res[0, 0] = -1;

            return res;
        }
        public static Matrix4 TransXY()
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            res[2, 2] = -1;

            return res;
        }

        public static Matrix4 Scale(float a, float b, float c)
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            res[0, 0] = a;
            res[1, 1] = b;
            res[2, 2] = c;

            return res;
        }
        #endregion
    }
}
