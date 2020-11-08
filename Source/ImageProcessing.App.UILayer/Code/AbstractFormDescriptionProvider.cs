using System;
using System.ComponentModel;

namespace ImageProcessing.App.UILayer.Code.Attributes
{
    public class AbstractFormDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public AbstractFormDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        {

        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(TAbstract))
            {
                return typeof(TBase);
            }
                
            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(TAbstract))
            {
                objectType = typeof(TBase);
            }
                
            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}
