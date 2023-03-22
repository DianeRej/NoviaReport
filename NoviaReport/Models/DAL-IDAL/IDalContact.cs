﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models.DAL_IDAL
{
    interface IDalContact : IDisposable
    {
        void DeleteCreateDatabase();

        int CreateContact(string PersonalMail, int PersonalPhone, string ProMail, int ProPhone);

        public int CreateContact(string personalMail, int personalPhone, string proMail,
           int proPhone, Adress adress, int adressId);
        void UpdateContact(int id, string PersonalMail, int PersonalPhone, string ProMail, int ProPhone);
        void DeleteContact(int id);

        List<Contact> GetAllContact();



       
    }
}