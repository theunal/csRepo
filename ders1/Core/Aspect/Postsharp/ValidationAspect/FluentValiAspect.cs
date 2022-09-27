using Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.Postsharp.ValidationAspect
{
    [Serializable]
    public class FluentValiAspect : OnMethodBoundaryAspect
    {
        private Type validatorType;

        public FluentValiAspect(Type validatorType)
        {
            this.validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(validatorType);
            var entityType = validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(p => p.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidatorTool.FluentVali(validator, entity);
            }
        }
    }
}
