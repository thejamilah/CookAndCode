//using Microsoft.AspNetCore.Authorization;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace Cookware.Models.Handlers
//{
//    public class LanguageRequirements : AuthorizationHandler<LanguageRequirements>, IAuthorizationRequirement
//    {
//        string _languagereq;

//        public LanguageRequirements(string languagereq)
//        {
//            _languagereq = languagereq;
//        }

//        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LanguageRequirements requirement)
//        {
//            if (!context.User.HasClaim(l => l.Type == "FavoriteLanguage"))
//            {
//                return Task.CompletedTask;
//            }

//            if (context.User.FindFirstValue(x => x.Type == )

//            return Task.CompletedTask;


//        }

//    }

//}
