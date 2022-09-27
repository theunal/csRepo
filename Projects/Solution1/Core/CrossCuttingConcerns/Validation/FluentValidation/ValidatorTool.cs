using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool 
    {
        public static void FluentValidate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity); // burası önemli kodlar değişmiş
            var result = validator.Validate(context);           // validate artık bir context istiyor 
                                                            // o yüzden ValidationContext'e object verdim
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
