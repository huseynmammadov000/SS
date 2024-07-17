﻿using StartupShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Repositories.CategoryRepository
{
    public interface ICategoryReadRepository :IReadRepository<Category>
    {
    }
}