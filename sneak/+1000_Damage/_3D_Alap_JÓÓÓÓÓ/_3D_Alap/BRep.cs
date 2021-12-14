using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Alap
{
    public class BRep
    {
        public List<Vector3> vertices = new List<Vector3>();
        public List<Line3D> lines = new List<Line3D>();
        public List<Triangle3D> triangles = new List<Triangle3D>();
    }
}
