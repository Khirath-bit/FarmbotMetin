using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmbotMetin
{
    internal static class Extensions
    {
        public static List<float[]> ArrayTo2DList(this Array array)
        {
            var list = new List<float[]>();

            var temp = new List<float>();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                temp.Clear();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    temp.Add(float.Parse(array.GetValue(i, j).ToString()));
                }
                list.Add(temp.ToArray());
            }

            return list;
        }
    }
}
