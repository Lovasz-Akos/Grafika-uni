using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace _3D_Alap
{
    public class FileReader
    {
        public static BRep FromWaveFront(string filePath)
        {
            BRep brep = new BRep();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string row;
                while (!sr.EndOfStream)
                {
                    row = sr.ReadLine();
                    string[] data = row.Split(' ');
                    switch (data[0])
                    {
                        case "v":
                            brep.vertices.Add(new Vector3(float.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat),
                                                          float.Parse(data[2], CultureInfo.InvariantCulture.NumberFormat),
                                                          float.Parse(data[3], CultureInfo.InvariantCulture.NumberFormat)));
                            break;
                        case "f":
                            brep.triangles.Add(new Triangle3D(brep.vertices[int.Parse(data[1]) - 1],
                                                              brep.vertices[int.Parse(data[2]) - 1],
                                                              brep.vertices[int.Parse(data[3]) - 1]));
                            break;
                        default: break;
                    }
                }
                sr.Close();
            }
            return brep;
        }
    }
}
