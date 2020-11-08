using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ImageProcessing.App.UILayer.Code.Extensions
{
    public static class TypeExtensions
    {

        public static Dictionary<int, Delegate> _cache
            = new Dictionary<int, Delegate>();

        public static Delegate CreateDelegate(this MethodInfo methodInfo, object target)
        {
            var code = methodInfo.GetHashCode();

            if (_cache.TryGetValue(code, out var method))
            {
                return method;
            }

            Func<Type[], Type> getType;
            var isAction = methodInfo.ReturnType.Equals((typeof(void)));
            var types = methodInfo.GetParameters().Select(p => p.ParameterType);

            if (isAction)
            {
                getType = Expression.GetActionType;
            }
            else
            {
                getType = Expression.GetFuncType;
                types = types.Concat(new[] { methodInfo.ReturnType });
            }

            if (methodInfo.IsStatic)
            {
               var staticDel = Delegate.CreateDelegate(getType(types.ToArray()), methodInfo);

                _cache.Add(code, staticDel);

                return staticDel;

            }

            var del = Delegate.CreateDelegate(getType(types.ToArray()), target, methodInfo.Name);

            _cache.Add(code, del);

            return del;
        }
    }
}
