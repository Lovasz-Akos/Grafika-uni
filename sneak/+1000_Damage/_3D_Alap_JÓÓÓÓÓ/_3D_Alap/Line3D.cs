using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Alap
{
    public class Line3D
    {
        public Vector3 v0, v1;

        public Line3D(Vector3 v0, Vector3 v1)
        {
            this.v0 = new Vector3(v0.x, v0.y, v0.z, v0.w);
            this.v1 = new Vector3(v1.x, v1.y, v1.z, v1.w);
        }
        public Line3D(Line3D l)
            :this(l.v0, l.v1)
        {

        }
    }
}
