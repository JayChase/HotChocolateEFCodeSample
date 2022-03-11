using System.Reflection;
using System.Runtime.CompilerServices;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using CodeSample.Data;

namespace CodeSample
{
    public class UseTestDbContextAttribute : UseDbContextAttribute
    {
        public UseTestDbContextAttribute([CallerLineNumber] int order = 0) : base(typeof(TestDbContext))
        {
            Order = order;
        }
    }
}