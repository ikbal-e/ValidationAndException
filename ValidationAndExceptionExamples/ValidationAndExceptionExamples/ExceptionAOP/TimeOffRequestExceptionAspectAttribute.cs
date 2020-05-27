using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.ExceptionAOP
{
    [Serializable]
    public class TimeOffRequestExceptionAspectAttribute : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            if (args.Exception.GetType().Equals(typeof(StartDateGreaterThanEndDateException)))
            {
                Console.WriteLine("End date cannot be greater than the start date");
                args.FlowBehavior = FlowBehavior.Continue;
            }
            else
                base.OnException(args);  
        }
    }
}