using System;
using System.Collections.Generic;
using System.Text;
using Utils.DInjection;
using Services.Business;
using Data;
using Data.Repositories;

namespace Services
{
    public class DiRegisterServices
    {
        public static List<IClassType> GetServiceList()
        {
            var list = new List<IClassType>();
            list.AddRange(DiRegisterData.GetDataList());
            list.Add(new ClassType<ICuestionarioRegistroServices, CuestionarioRegistroServices>());
            list.Add(new ClassType<IOpcionServices, OpcionServices>());
            return list;
        }
    }
}
