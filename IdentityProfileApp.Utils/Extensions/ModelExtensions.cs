using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IdentityProfileApp.Utils.Extensions
{
    public static class ModelExtensions
    {
        public static string ParseModelStateErrors(this ModelStateDictionary modelStates)
        {
            
            StringBuilder sb = new StringBuilder();
            foreach (var state in modelStates)
            {
                foreach (var error in state.Value.Errors)
                {
                    sb.AppendFormat("{0}<br/>", error.ErrorMessage);
                }
            }
            return sb.ToString();
        }

        public static string ParseDbValidationErrors(this DbEntityValidationException validationExceptions)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var valEx in validationExceptions.EntityValidationErrors)
            {
                foreach (var error in valEx.ValidationErrors)
                {
                    sb.AppendFormat("{0}<br/>", error.ErrorMessage);
                }
            }
            return sb.ToString();
        }
    }
}