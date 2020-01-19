using System;

namespace ImageProcessing.Common.Helpers
{
    public static class Requires
    {
        public static T IsNotNull<T>(T instance, string paramName) where T : class
        {
            // Use ReferenceEquals in case T overrides equals.
            if (object.ReferenceEquals(null, instance)) {
                throw new ArgumentNullException(paramName);
            }

            return instance;
        }
        
        public static void IsTrue(Func<bool> isTrue, string errorMessage)
        {
            IsNotNull(isTrue, nameof(isTrue));

            if(!isTrue())
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
