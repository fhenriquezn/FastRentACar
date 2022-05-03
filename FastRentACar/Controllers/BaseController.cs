using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastRentACar.Controllers
{
    public class BaseController<TEntity> : ControllerBase
    {
        public IEnumerable<string> PatchProperties(TEntity patchEntity)
        {
            return typeof(TEntity).GetProperties()
            .Select(x => Tuple.Create(x.Name, x.GetValue(patchEntity)))
            .Where(x => x.Item2 != null)
            .ToList().Select(s => s.Item1);
        }
    }
}
