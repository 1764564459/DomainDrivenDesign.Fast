using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Domain.Core.Entity
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        /// <summary>
        /// 重写相等
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var _value = obj as T;
            return !ReferenceEquals(_value, null) && EquilsCore(_value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected abstract bool EquilsCore(T obj);

        /// <summary>
        /// 重写获取HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }


        public abstract int GetHashCodeCore();

        /// <summary>
        /// 重写方法 实体比较 ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        /// <summary>
        /// 重写方法 实体比较 !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }

        /// <summary>
        /// 克隆副本
        /// </summary>
        public virtual T Clone()
        {
            return (T)MemberwiseClone();
        }
    }
}
