using System;

namespace Leanwork.CodePack
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Verifica se é um tipo Nullable
        /// </summary>
        /// <param name="type">Tipo do objeto.</param>
        /// <returns>Verdadeiro caso seja um tipo Nullable, senão, falso.</returns>
        public static bool IsNullable(this Type type)
        {
            return (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        }

        /// <summary>
        /// Alternative version of <see cref="Type.IsSubclassOf"/> that supports raw generic types (generic types without
        /// any type parameters).
        /// </summary>
        /// <param name="baseType">The base type class for which the check is made.</param>
        /// <param name="toCheck">To type to determine for whether it derives from <paramref name="baseType"/>.</param>
        public static bool IsSubclassOfRawGeneric(this Type toCheck, Type baseType)
        {
            while (toCheck != typeof(object))
            {
                Type cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (baseType == cur)
                {
                    return true;
                }

                toCheck = toCheck.BaseType;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsDerived<T>(this Type type)
        {
            Type baseType = typeof(T);

            if (baseType.FullName == type.FullName)
            {
                return true;
            }

            if (type.IsClass)
            {
                return baseType.IsClass
                    ? type.IsSubclassOf(baseType)
                    : baseType.IsInterface
                        ? IsImplemented(type, baseType)
                        : false;
            }
            else if (type.IsInterface && baseType.IsInterface)
            {
                return IsImplemented(type, baseType);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="baseType"></param>
        /// <returns></returns>
        public static bool IsImplemented(Type type, Type baseType)
        {
            Type[] faces = type.GetInterfaces();
            foreach (Type face in faces)
            {
                if (baseType.Name.Equals(face.Name))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Is<T>(this Type type)
        {
            return type.Equals(typeof(T));
        }
    }
}
