﻿using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Repository
{
    public interface IHomePageRepository
    {
        Homepage GetHomePage();
        void CreateHomePage(Homepage homepage);
        void UpdateHomePage(Homepage homepage);
    }
   
}