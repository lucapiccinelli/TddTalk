using System.Collections.Generic;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Domain.Doors
{
    public interface IRepository<T>
    {
        List<T> ReadAll();
        void New(T t);
    }
}