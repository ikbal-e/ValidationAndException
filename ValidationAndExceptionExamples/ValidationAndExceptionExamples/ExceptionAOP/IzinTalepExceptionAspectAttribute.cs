using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.ExceptionAOP
{
    [Serializable]
    public class IzinTalepExceptionAspectAttribute : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            if (args.Exception.GetType().Equals(typeof(IzinTalepBaslangicBitistenIleriOlamazException)))
            {
                Console.WriteLine("Başlangıç tarihi bitiş tarihinden ileri bir tarihte olamaz");
                args.FlowBehavior = FlowBehavior.Continue;
            }
            else
                base.OnException(args);
            
        }
    }
}