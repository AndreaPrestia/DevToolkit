using System;

namespace DevToolkit.Helpers
{
    public static class Reflection
    {
        public static T CreateInstance<T>(string typeName) where T : class, new()
        {
            Type type = Type.GetType(typeName);

            if (type == null)
            {
                throw new TypeLoadException(typeName);
            }

            T p = Activator.CreateInstance(type) as T;

            if (p == null)
            {
                throw new Exception(String.Format("Cannot create instance for type  {0}.", type.FullName));
            }

            return p;
        }

        public static T CreateInstance<T>(Type type) where T : class, new()
        {
            if (type == null)
            {
                throw new ArgumentNullException($"{nameof(type)} is null.");
            }

            T p = Activator.CreateInstance(type) as T;

            if (p == null)
            {
                throw new Exception(String.Format("Cannot create instance for type  {0}.", type.FullName));
            }

            return p;
        }

        public static object CreateInstance(string typeName)
        {
            Type type = Type.GetType(typeName);

            if (type == null)
            {
                throw new TypeLoadException(typeName);
            }

            object obj = Activator.CreateInstance(type);

            if (obj == null)
            {
                throw new Exception(String.Format("Cannot create instance for type  {0}.", type.FullName));
            }

            return obj;
        }

        public static object CreateInstance(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException($"{nameof(type)} is null.");
            }

            object obj = Activator.CreateInstance(type);

            if (obj == null)
            {
                throw new Exception(String.Format("Cannot create instance for type  {0}.", type.FullName));
            }

            return obj;
        }
    }
}
