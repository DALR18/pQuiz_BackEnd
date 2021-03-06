﻿using System;
using System.Collections.Generic;
using System.Text;
using Utils.DInjection;
using Data.Repositories;

namespace Data
{
    public class DiRegisterData
    {
        public static List<IClassType> GetDataList()
        {
            var list = new List<IClassType>();
            list.Add(new ClassType<ICuestionarioRegistroRepository, CuestionarioRegistroRepository>());
            list.Add(new ClassType<IOpcionRepository, OpcionRepository>());
            return list;
        }
    }
}
