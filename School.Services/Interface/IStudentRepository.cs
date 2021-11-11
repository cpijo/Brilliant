﻿using School.Entities.Fields;
using System.Collections.Generic;
namespace School.Services.Interface
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        List<Student> GetByColumn(string columnName, string value);
        //Student GetOneByColumn(string columnName, string value);
    }
}