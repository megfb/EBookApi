﻿using EBookApi.Entities.Entities;
using EBookApi.Repositories.DbServices;
using EBookApi.Repositories.GenericRepository;

namespace EBookApi.Repositories.DbEntities.Categories
{
    public class CategoryRepsitory(AppDbContext appDbContext) : PgGenericRepository<Category>(appDbContext), ICategoryRepository
    {
    }
}
