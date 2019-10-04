using Microsoft.AspNetCore.Authorization;
using System;

namespace InnoCVExercise.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SecurityAttribute : AuthorizeAttribute
    {
    }    
}
