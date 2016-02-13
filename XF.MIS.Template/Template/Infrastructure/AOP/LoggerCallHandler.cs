//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Web;
//using MasterData.ServiceBusProvider;
//using Microsoft.Practices.Unity.InterceptionExtension;
//using ServiceStack.Redis;
//
//namespace $safeprojectname$.Infrastructure.AOP
//{
//    public class LoggerCallHandler : ICallHandler
//    {
//        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
//        {
//            IMethodReturn result = getNext()(input, getNext);
//
//            try
//            {
//                //操作人
//                var oper = HttpContext.Current == null ? "" :
//                    HttpContext.Current.Session["UserMenuSessionToken"];
//
//                var systemCode = ConfigurationManager.AppSettings["SystemCode_Check"];
//                var operationTime = DateTime.Now;
//                var methodName = input.MethodBase.Name;
//
//                var list = new List<KeyValuePair<string, object>>();
//                for (int i = 0; i < input.Arguments.Count; i++)
//                {
//                    var parameterName = input.Arguments.ParameterName(i);
//                    var parameter = input.Arguments[i];
//                    var kv = new KeyValuePair<string, object>(parameterName, parameter);
//                    list.Add(kv);
//                }
//
//                object methodReturn = null;
//                if (result.ReturnValue != null)
//                    methodReturn = result.ReturnValue;
//
//                var isException = false;
//                Exception exception = null;
//                if (result.Exception != null)
//                {
//                    isException = true;
//                    exception = result.Exception;
//                }
//
//                var stackTrace = Environment.StackTrace;
//
//                var log = new
//                {
//                    Operator = oper,
//                    SystemCode = systemCode,
//                    OperationTime = operationTime,
//                    MethodName = methodName,
//                    MethodParameters = list,
//                    MethodReturn = methodReturn,
//                    IsException = isException,
//                    Exception = exception,
//                    StackTrace = stackTrace
//                };
//
//                var redisClientManager = Ioc.R<IRedisClientsManager>("loggerClientManager");
//                using (var redis = redisClientManager.GetClient())
//                {
//                    redis.Password = ConfigurationManager.AppSettings["loggerClientManagerPwd"];
//                    //将日志信息入队
//                    redis.EnqueueItemOnList("Logger", log.SerializeObject());
//                }
//            }
//            catch (Exception ex)
//            {
//                LogInstance.Error("记录日志出错.", ex);
//            }
//            return result;
//        }
//
//        public int Order { get; set; }
//    }
//}
