using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExercices.WebApp.TypeHandler
{
    public interface ITypeHandler
    {
        dynamic Decode(dynamic contents);
        dynamic Encode(dynamic datas);
    }
}
