using System;

namespace ImageProcessing.App.Common.Helpers
{
    public static class Requires
    {
        /// <summary>
        /// Check whether the specified reference type is null.
        /// </summary>
        /// <typeparam name="TReference">A reference type.</typeparam>
        /// <param name="instance">The source object instance.</param>
        /// <param name="arg">The name of the source object.</param>
        /// <returns></returns>
        public static TReference IsNotNull<TReference>(TReference instance, string arg)
            where TReference : class
        {
            if (instance is null)
            {
                throw new ArgumentNullException(arg);
            }

            return instance;
        }

        /// <summary>
        /// Check whether specified predicate
        /// is true.
        /// </summary>
        /// <param name="isTrue">The specified predicate</param>
        /// <param name="errorMessage">An error on false result.</param>
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
