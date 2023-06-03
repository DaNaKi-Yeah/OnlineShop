﻿using AutoMapper;
using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.Handlers
{
    public class UserHandler : BaseHandler<User, int>
    {
        public UserHandler(IRepository<User, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
