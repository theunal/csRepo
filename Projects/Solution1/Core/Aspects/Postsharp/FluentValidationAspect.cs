using Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Aspects.Postsharp
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        Type validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            this.validatorType = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(validatorType);
            var entityType = validatorType.BaseType.GetGenericArguments()[0]; // dizideki ilk değeri al diyor "product"
            var entities = args.Arguments.Where(p => p.GetType() == entityType); 

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }
    }
}
