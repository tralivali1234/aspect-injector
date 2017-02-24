﻿using AspectInjector.Broker;
using System;
using System.Reflection;

namespace AspectInjector.Tests.Assets
{
    [Aspect(Aspect.Scope.PerInstance)]
    public class InstanceAspect : TestAspectBase
    {
        public static readonly string AfterExecuted = "AfterAspectInstance";
        public static readonly string BeforeExecuted = "BeforeAspectInstance";
        public static readonly string AroundEnter = "AroundAspectInstanceEnter";
        public static readonly string AroundExit = "AroundAspectInstanceExit";

        [Advice(Advice.Type.After, Advice.Target.Constructor | Advice.Target.EventAdd | Advice.Target.EventRemove | Advice.Target.Getter | Advice.Target.Method | Advice.Target.Setter)]
        public void After(
            [Advice.Argument(Advice.Argument.Source.Arguments)] object[] args,
            [Advice.Argument(Advice.Argument.Source.Attributes)] Attribute[] attrs,
            [Advice.Argument(Advice.Argument.Source.Instance)] object _this,
            [Advice.Argument(Advice.Argument.Source.Method)] MethodBase method,
            [Advice.Argument(Advice.Argument.Source.Name)] string name,
            [Advice.Argument(Advice.Argument.Source.ReturnType)] Type retType,
            [Advice.Argument(Advice.Argument.Source.ReturnValue)] object retVal,
            [Advice.Argument(Advice.Argument.Source.Target)] Func<object[], object> target,
            [Advice.Argument(Advice.Argument.Source.Type)] Type hostType
            )
        {
            base.LogArguments(args, AfterExecuted);
            base.LogAttributes(args, AfterExecuted);
            base.LogInstance(_this, AfterExecuted);
            base.LogMethod(method, AfterExecuted);
            base.LogName(name, AfterExecuted);
            base.LogReturnType(retType, AfterExecuted);
            base.LogReturnValue(retVal, AfterExecuted);
            base.LogTarget(target, AfterExecuted);
            base.LogType(hostType, AfterExecuted);

            TestLog.Write(AfterExecuted);
        }

        [Advice(Advice.Type.Before, Advice.Target.Constructor | Advice.Target.EventAdd | Advice.Target.EventRemove | Advice.Target.Getter | Advice.Target.Method | Advice.Target.Setter)]
        public void Before(
            [Advice.Argument(Advice.Argument.Source.Arguments)] object[] args,
            [Advice.Argument(Advice.Argument.Source.Attributes)] Attribute[] attrs,
            [Advice.Argument(Advice.Argument.Source.Instance)] object _this,
            [Advice.Argument(Advice.Argument.Source.Method)] MethodBase method,
            [Advice.Argument(Advice.Argument.Source.Name)] string name,
            [Advice.Argument(Advice.Argument.Source.ReturnType)] Type retType,
            [Advice.Argument(Advice.Argument.Source.ReturnValue)] object retVal,
            [Advice.Argument(Advice.Argument.Source.Target)] Func<object[], object> target,
            [Advice.Argument(Advice.Argument.Source.Type)] Type hostType
            )
        {
            base.LogArguments(args, BeforeExecuted);
            base.LogAttributes(args, BeforeExecuted);
            base.LogInstance(_this, BeforeExecuted);
            base.LogMethod(method, BeforeExecuted);
            base.LogName(name, BeforeExecuted);
            base.LogReturnType(retType, BeforeExecuted);
            base.LogReturnValue(retVal, BeforeExecuted);
            base.LogTarget(target, BeforeExecuted);
            base.LogType(hostType, BeforeExecuted);

            TestLog.Write(BeforeExecuted);
        }

        [Advice(Advice.Type.Around, Advice.Target.Constructor | Advice.Target.EventAdd | Advice.Target.EventRemove | Advice.Target.Getter | Advice.Target.Method | Advice.Target.Setter)]
        public object Around(
            [Advice.Argument(Advice.Argument.Source.Arguments)] object[] args,
            [Advice.Argument(Advice.Argument.Source.Attributes)] Attribute[] attrs,
            [Advice.Argument(Advice.Argument.Source.Instance)] object _this,
            [Advice.Argument(Advice.Argument.Source.Method)] MethodBase method,
            [Advice.Argument(Advice.Argument.Source.Name)] string name,
            [Advice.Argument(Advice.Argument.Source.ReturnType)] Type retType,
            [Advice.Argument(Advice.Argument.Source.ReturnValue)] object retVal,
            [Advice.Argument(Advice.Argument.Source.Target)] Func<object[], object> target,
            [Advice.Argument(Advice.Argument.Source.Type)] Type hostType
            )
        {
            base.LogArguments(args, AroundEnter);
            base.LogAttributes(args, AroundEnter);
            base.LogInstance(_this, AroundEnter);
            base.LogMethod(method, AroundEnter);
            base.LogName(name, AroundEnter);
            base.LogReturnType(retType, AroundEnter);
            base.LogReturnValue(retVal, AroundEnter);
            base.LogTarget(target, AroundEnter);
            base.LogType(hostType, AroundEnter);

            TestLog.Write(AroundEnter);
            var result = target(args);
            TestLog.Write(AroundExit);
            return result;
        }
    }
}