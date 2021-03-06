﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Model;

namespace Core.Repository
{
    public interface IRepo<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        int Count();
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false);
        void Insert(T o);
        void Save();
        void Delete(T o);
        void Restore(T o);
    }

    public interface IUniRepo
    {
        void Insert<T>(T o) where T : Entity;
        void Save();
        T Get<T>(int id) where T : Entity;
        IEnumerable<T> GetAll<T>() where T : Entity;
    }

    public interface IReadRepo<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}