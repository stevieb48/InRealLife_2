﻿using DataLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Repository : IRepository
    {
        DataBaseCommunication newDBComm = new DataBaseCommunication();
    }
}