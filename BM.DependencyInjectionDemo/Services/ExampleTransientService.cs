using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BM.DependencyInjectionDemo.Interfaces;

namespace BM.DependencyInjectionDemo.Services
{
    public class ExampleTransientService : IExampleTransientService
    {
        private readonly Guid Id;

        public ExampleTransientService()
        {
            Id = Guid.NewGuid();
        }

        public string GetGuid() => Id.ToString();
    }
}
