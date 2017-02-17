﻿using AspectInjector.Core.Advice.Effects;
using AspectInjector.Core.Contracts;
using AspectInjector.Core.Fluent;
using AspectInjector.Core.Models;
using Mono.Cecil;

namespace AspectInjector.Core.Advice.Weavers.Processes
{
    internal class AdviceAfterProcess : AdviceWeaveProcessBase<AfterAdviceEffect>
    {
        public AdviceAfterProcess(ILogger log, MethodDefinition target, AspectDefinition aspect, AfterAdviceEffect effect)
            : base(log, target, effect, aspect)
        {
        }

        public override void Execute()
        {
            _target.GetEditor().OnExit(
                e => e
                .LoadAspect(_aspect)
                .Call(_effect.Method, LoadAdviceArgs)
            );
        }
    }
}