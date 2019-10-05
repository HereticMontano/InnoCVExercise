using Microsoft.AspNetCore.Authorization;
using System;

namespace InnoCVExercise.PresentationLayer.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SecurityAttribute : AuthorizeAttribute
    {
    }    
}
