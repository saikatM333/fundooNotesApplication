﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces.EmailAction
{
    public  interface IemailServices
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
