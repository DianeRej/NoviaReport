﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    interface IDalProInfo : IDisposable
    {
       public void DeleteCreateDatabase();

        public int CreateProfessionalInfo(Position Position, Function Function, DateTime dateofarrival);

        public void UpdateProfessionalInfo(int id, Position Position, Function Function);
        public void DeleteProfessionalInfo(int id);

        public List<ProfessionalInfo> GetAllProfessionalInfo();
    }
}