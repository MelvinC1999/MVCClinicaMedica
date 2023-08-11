using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVCClinicaMedica.DBContext;
using MVCClinicaMedica.Models;
using System;
using System.Linq;

namespace MVCClinicaMedica.Filtros
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AutorizarUsuario : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly int[] allowedOperaciones;

        public AutorizarUsuario(params int[] allowedOperaciones)
        {
            this.allowedOperaciones = allowedOperaciones;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var db = context.HttpContext.RequestServices.GetRequiredService<BaseEFContext>();
            var usuario = context.HttpContext.User.Identity.IsAuthenticated
                ? db.Usuarios.FirstOrDefault(u => u.Correo == context.HttpContext.User.Identity.Name)
                : null;

            if (usuario == null)
            {
                context.Result = new RedirectResult("~/Error/UnauthorizedOperation");
                return;
            }

            var rolOperacion = db.RolOperaciones
                .FirstOrDefault(ro => ro.idRol == usuario.idRol && allowedOperaciones.Contains(ro.idOperacion));

            if (rolOperacion == null)
            {
                context.Result = new RedirectResult($"~/Error/UnauthorizedOperation");
                return;
            }
        }
    }
}
