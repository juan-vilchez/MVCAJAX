using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAJAX.Proxy
{
    public class ResponseProxy<TEntity> : ICloneable where TEntity : class, new()
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public bool Exitoso { get; set; }
        public IEnumerable<TEntity> listado { get; set; }
        public TEntity objeto { get;set;}
        public object Clone() 
        {
            return this.MemberwiseClone();
        }
    }
}