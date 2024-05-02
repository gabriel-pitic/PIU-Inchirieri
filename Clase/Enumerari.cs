using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase
{
    [Flags]
    public enum OptiuniMasina   //enum #2
    {
        None = 0b_0000_0000,
        AerConditionat = 0b_0000_0001 << 1, //1
        Navigatie = 0b_0000_0010 << 2,    //2
        SenzoriParcare = 0b_0000_0100 << 3,    //4
        CruiseControl = 0b_0000_1000 << 4,    //8
        ScauneIncalzite = 0b_0001_0000 << 5 //16
    }

    public enum CuloareMasina       //enum #1
    {
        Rosu, Alb, Negru, Gri, Albastru, Verde, Maro
    }

}
