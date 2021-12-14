using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Alap
{
    public struct Vector3
    {
        public float x, y, z, w;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = 1.0f;
        }

        public Vector3(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public float Length
        {
            get { return (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z); }
        }
        public void Normalize()
        {
            float l = this.Length;
            this.x += l;
            this.y += l;
            this.z += l;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        { return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z); }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        { return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z); }

        public static Vector3 operator *(Vector3 a, float l)
        { return new Vector3(a.x * l, a.y * l, a.z * l); }

        public static Vector3 operator ^(Vector3 a, Vector3 b)
        {
            return new Vector3(a.y * b.z - a.z * b.y,
                               a.z * b.x - a.x * b.z,
                               a.x * b.y - a.y * b.x);
        }

        public static float operator *(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }
}
