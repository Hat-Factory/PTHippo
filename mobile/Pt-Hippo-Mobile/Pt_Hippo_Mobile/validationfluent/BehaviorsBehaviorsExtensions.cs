using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Vaildation;
using System.Linq.Expressions;

namespace Pt_Hippo_Mobile.validationfluent
{
     public static class  BehaviorsBehaviorsExtensions
    {
       

            public static FluentValidation When<T>

                (this T subject, Expression<Func<T, bool>> expressionProperty)

            {

                Func<T, bool> func = expressionProperty.Compile();

                bool hasValidation = func(subject);



                return new FluentValidation(hasValidation);

            }



            public static FluentValidation When<TValidator>

                (this ValidationCollected validationCollected,

                    TValidator subject,

                    Expression<Func<TValidator, bool>> expressionProperty)

            {

                Func<TValidator, bool> func = expressionProperty.Compile();

                bool hasValidation = func(subject);



                return new FluentValidation(validationCollected, hasValidation);

            }

        }

    }