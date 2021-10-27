using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BM.DependencyInjectionDemo.Interfaces;

namespace BM.DependencyInjectionDemo.Services
{
    public class ExampleSingletonService : IExampleSingletonService
    {
        private readonly Guid Id;

        public ExampleSingletonService()
        {
            Id = Guid.NewGuid();
        }

        public string GetGuid() => Id.ToString();
    }
}
