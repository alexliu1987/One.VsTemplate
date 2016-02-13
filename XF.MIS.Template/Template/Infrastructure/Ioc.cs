using System;
using Autofac;

namespace $safeprojectname$.Infrastructure
{
    public static class Ioc
    {
        private static readonly object Locker = new object();
        private static IContainer _container;

        /// <summary>
        /// 初始化Autofac容器
        /// </summary>
        /// <param name="action">初始化操作</param>
        /// <param name="afterAction">初始化之后针对Container进行操作</param>
        public static void InitializeWith(Action<ContainerBuilder> action,
            Action<IContainer> afterAction = null)
        {
            if (_container != null)
                return;
            lock (Locker)
            {
                if (_container != null)
                    return;
                var builder = new ContainerBuilder();
                action(builder);
                _container = builder.Build();
                afterAction?.Invoke(_container);
            }
        }

        /// <summary>
        /// 容器中获取对象
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <returns></returns>
        public static T R<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
