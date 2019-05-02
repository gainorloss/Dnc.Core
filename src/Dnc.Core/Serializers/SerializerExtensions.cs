using Dnc.Serializers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc
{
    public static class SerializerExtensions
    {
        internal static FrameworkConstruction UseDefaultSerializer(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IMessageSerializer, NewtonsoftJsonSerializer>();
            return construction;
        }


        /// <summary>
        /// Get it from a <see cref="IMessageSerializer"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="construction"></param>
        /// <param name="configureMessageSerializer"></param>
        /// <returns></returns>
        public static FrameworkConstruction UseSerializer<T>(this FrameworkConstruction construction,
             Func<IServiceCollection, IMessageSerializer> configureMessageSerializer = null)
        {
            var serializer = configureMessageSerializer.Invoke(construction.Services);
            construction.Services.AddSingleton(serializer);
            return construction;
        }
    }
}
