using System;
using System.Collections.Generic;

namespace $safeprojectname$.Domain.Repositories
{
    /// <summary>
    /// 领域模型基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class EntityBase<T> where T : struct
    {
        /// <summary>
        /// 主键
        /// </summary>
        public T Id { get; set; }

//        /// <summary>
//        /// 验证方法
//        /// </summary>
//        /// <typeparam name="TV">验证器</typeparam>
//        /// <returns>验证错误消息</returns>
//        public IEnumerable<string> Validate<TV>() where TV : IValidator, new()
//        {
//            var am = new TV();
//            var result = am.Validate(this);
//            if (result.IsValid) yield break;
//            foreach (var error in result.Errors)
//                yield return error.ErrorMessage;
//        }
    }
}