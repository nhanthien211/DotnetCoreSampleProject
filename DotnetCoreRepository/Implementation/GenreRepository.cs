﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using DotnetCoreEntity;
using DotnetCoreRepository.Interface;

namespace DotnetCoreRepository.Implementation
{
    public class GenreRepository : IGenreRepository
    {
        private IUnitOfWork _unitOfWork;

        public GenreRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Insert(Genre genre)
        {
            string sql = "insert into genre (name) values (@name)";
            var param = new DynamicParameters();
            param.Add("@name", genre.Name);
            int result = _unitOfWork.Connection.Execute(sql, param, _unitOfWork.Transaction);
            return result > 0;
        }
    }
}
