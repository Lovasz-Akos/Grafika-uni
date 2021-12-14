using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Alap
{
    public class ObjectBRep3D
    {
        public ObjectBRep3D()
        {
            this.transformation = new Matrix4();
            this.transformation.LoadIdentity();
        }

        public BRep model = new BRep();
        public Matrix4 transformation;
    }
}
