﻿using Bookify.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Users.GetLoggedInUser
{
    public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;
}