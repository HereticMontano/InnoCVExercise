using Microsoft.AspNetCore.Mvc;
using System;

namespace InnoCVExercise.Test.Helpers
{
    public static class Extension
    {
        //Por algun motivo que no logro dilusidar cuando el ActionResult retorna algo mas complejo que un modelo (como una lista de modelos)
        //no setea el Value del action y hay que hacer un juego de cast para obtenerlo.        
        public static T GetValue<T>(this ActionResult<T> action)
        {
            if (action.Value != null)
                return action.Value;
            else
                return (T)Convert.ChangeType((action.Result as ObjectResult)?.Value, typeof(T));
        }
    }
}
