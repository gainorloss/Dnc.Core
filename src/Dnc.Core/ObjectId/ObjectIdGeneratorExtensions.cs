using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.ObjectId
{
    public static class ObjectIdGeneratorExtensions
    {
        /// <summary>
        /// Uses object id generator in framework ,get it from a <see cref="IObjectIdGenerator"/>.
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction UseObjectIdGenerator(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IObjectIdGenerator,ObjectIdGenerator>();
            return construction;
        }
    }
}
