﻿using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Repository
{
    public interface IContactuspageRepository
    {
        Contactuspage GetAllContactusPages();
        void CreateContactusPage(Contactuspage contactuspage);
        void UpdateContactusPage(Contactuspage contactuspage);
    }
}
