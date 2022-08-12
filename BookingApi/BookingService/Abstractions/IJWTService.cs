﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Abstractions
{
    public interface IJWTService
    {
        string GenerateSecurityToken(string userName);
    }
}
