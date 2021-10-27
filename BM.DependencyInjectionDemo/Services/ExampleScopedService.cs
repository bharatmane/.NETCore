using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BM.DependencyInjectionDemo.Interfaces;

namespace BM.DependencyInjectionDemo.Services
{
    public class ExampleScopedService : IExampleScopedService
    {
        private readonly Guid Id;

        public ExampleScopedService()
        {
            Id = Guid.NewGuid();
        }

        public string GetGuid() => Id.ToString();
    }
}
