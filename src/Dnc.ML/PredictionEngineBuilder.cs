using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.Reflection;

namespace Dnc.ML
{
    public class PredictionEngineBuilder<TSrc, TDst>
            where TSrc : class
            where TDst : class, new()
    {
        public PredictionEngine<TSrc, TDst> Build(Func<DataOperationsCatalog, IDataView> buildDataViewFactory)
        {
            if (buildDataViewFactory == null)
                throw new ArgumentNullException(nameof(buildDataViewFactory));

            var propsDst = typeof(TDst).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttribute(typeof(ColumnNameAttribute), false) != null);
            if (propsDst == null || propsDst.Count() != 1)
                throw new System.Exception("the count of the property assigned to be predicted is only be 1.");

            var propsSrc = typeof(TSrc).GetProperties(BindingFlags.Public | BindingFlags.Instance).AsEnumerable();

            propsSrc = propsSrc.Except(propsDst, new PropertyInfoEqualityComparer());

            if (propsSrc == null || !propsSrc.Any())
                throw new Exception("the properties input are not allowed to be zero.");

            var ctx = new MLContext();
            var trainingData = buildDataViewFactory(ctx.Data);

            var propArr = propsSrc.Select(p => p.Name).ToArray();
            var pipeline = ctx.Transforms.Concatenate("Features", propArr)
                   .Append(ctx.Regression.Trainers.Sdca(labelColumnName: string.Join(",", propsDst.Select(p => p.Name)), maximumNumberOfIterations: 100));
            var model = pipeline.Fit(trainingData);
            var engine = ctx.Model.CreatePredictionEngine<TSrc, TDst>(model);
            return engine;
        }
    }
}
