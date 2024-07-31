﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Users.GetLoggedInUser
{
    public sealed class UserResponse
    {
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string Name { get; init; }
    }
}
