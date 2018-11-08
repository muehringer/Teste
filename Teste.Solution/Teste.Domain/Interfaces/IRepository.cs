using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Domain.Interfaces
{
    public interface IRepository
    {
        List<Feed> Get();
    }
}
