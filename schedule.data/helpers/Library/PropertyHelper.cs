namespace schedule.data.helpers.Library
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    internal class PropertyHelper
    {
        private static readonly MethodInfo _callPropertyGetterByReferenceOpenGenericMethod = typeof(PropertyHelper).GetMethod("CallPropertyGetterByReference", BindingFlags.NonPublic | BindingFlags.Static);
        private static readonly MethodInfo _callPropertyGetterOpenGenericMethod = typeof(PropertyHelper).GetMethod("CallPropertyGetter", BindingFlags.NonPublic | BindingFlags.Static);
        private static readonly MethodInfo _callPropertySetterOpenGenericMethod = typeof(PropertyHelper).GetMethod("CallPropertySetter", BindingFlags.NonPublic | BindingFlags.Static);
        private static ConcurrentDictionary<Type, PropertyHelper[]> _reflectionCache = new ConcurrentDictionary<Type, PropertyHelper[]>();
        private Func<object, object> _valueGetter;

        public PropertyHelper(PropertyInfo property)
        {
            this.Name = property.Name;
            this._valueGetter = MakeFastPropertyGetter(property);
        }

        private static object CallPropertyGetter<TDeclaringType, TValue>(Func<TDeclaringType, TValue> getter, object @this)
        {
            return getter((TDeclaringType)@this);
        }

        private static object CallPropertyGetterByReference<TDeclaringType, TValue>(ByRefFunc<TDeclaringType, TValue> getter, object @this)
        {
            TDeclaringType arg = (TDeclaringType)@this;
            return getter(ref arg);
        }

        private static void CallPropertySetter<TDeclaringType, TValue>(Action<TDeclaringType, TValue> setter, object @this, object value)
        {
            setter((TDeclaringType)@this, (TValue)value);
        }

        private static PropertyHelper CreateInstance(PropertyInfo property)
        {
            return new PropertyHelper(property);
        }

        public static PropertyHelper[] GetProperties(object instance)
        {
            return GetProperties(instance, new Func<PropertyInfo, PropertyHelper>(PropertyHelper.CreateInstance), _reflectionCache);
        }

        protected static PropertyHelper[] GetProperties(object instance, Func<PropertyInfo, PropertyHelper> createPropertyHelper, ConcurrentDictionary<Type, PropertyHelper[]> cache)
        {
            PropertyHelper[] helperArray;
            Type key = instance.GetType();
            if (!cache.TryGetValue(key, out helperArray))
            {
                List<PropertyHelper> list = new List<PropertyHelper>();
                foreach (PropertyInfo info in key.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where<PropertyInfo>(ByRefFunc.GetFunc ?? (ByRefFunc.GetFunc = new Func<PropertyInfo, bool>(ByRefFunc.demo1.GetProperties))))
                {
                    PropertyHelper item = createPropertyHelper(info);
                    list.Add(item);
                }
                helperArray = list.ToArray();
                cache.TryAdd(key, helperArray);
            }
            return helperArray;
        }

        public object GetValue(object instance)
        {
            return this._valueGetter(instance);
        }

        public static Func<object, object> MakeFastPropertyGetter(PropertyInfo propertyInfo)
        {
            Delegate delegate2;
            MethodInfo getMethod = propertyInfo.GetGetMethod();
            Type reflectedType = getMethod.ReflectedType;
            Type returnType = getMethod.ReturnType;
            if (reflectedType.IsValueType)
            {
                Type[] typeArguments = new Type[] { reflectedType, returnType };
                Delegate firstArgument = getMethod.CreateDelegate(typeof(ByRefFunc).MakeGenericType(typeArguments));
                Type[] typeArray2 = new Type[] { reflectedType, returnType };
                MethodInfo method = _callPropertyGetterByReferenceOpenGenericMethod.MakeGenericMethod(typeArray2);
                delegate2 = Delegate.CreateDelegate(typeof(Func<object, object>), firstArgument, method);
            }
            else
            {
                Type[] typeArray3 = new Type[] { reflectedType, returnType };
                Delegate delegate4 = getMethod.CreateDelegate(typeof(Func<,>).MakeGenericType(typeArray3));
                Type[] typeArray4 = new Type[] { reflectedType, returnType };
                MethodInfo info3 = _callPropertyGetterOpenGenericMethod.MakeGenericMethod(typeArray4);
                delegate2 = Delegate.CreateDelegate(typeof(Func<object, object>), delegate4, info3);
            }
            return (Func<object, object>)delegate2;
        }

        public static Action<TDeclaringType, object> MakeFastPropertySetter<TDeclaringType>(PropertyInfo propertyInfo) where TDeclaringType : class
        {
            Type reflectedType = propertyInfo.ReflectedType;
            MethodInfo setMethod = propertyInfo.GetSetMethod();
            Type parameterType = setMethod.GetParameters()[0].ParameterType;
            Type[] typeArguments = new Type[] { reflectedType, parameterType };
            Delegate firstArgument = setMethod.CreateDelegate(typeof(Action<,>).MakeGenericType(typeArguments));
            Type[] typeArray2 = new Type[] { reflectedType, parameterType };
            MethodInfo method = _callPropertySetterOpenGenericMethod.MakeGenericMethod(typeArray2);
            return (Action<TDeclaringType, object>)Delegate.CreateDelegate(typeof(Action<TDeclaringType, object>), firstArgument, method);
        }

        public virtual string Name { get; protected set; }

        [Serializable, CompilerGenerated]
        private sealed class ByRefFunc
        {
            public static readonly PropertyHelper.ByRefFunc demo1 = new PropertyHelper.ByRefFunc();
            public static Func<PropertyInfo, bool> GetFunc;

            internal bool GetProperties(PropertyInfo prop)
            {
                return ((prop.GetIndexParameters().Length == 0) && (prop.GetMethod != null));
            }
        }

        private delegate TValue ByRefFunc<TDeclaringType, TValue>(ref TDeclaringType arg);
    }

}

