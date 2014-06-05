using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanSPA.Demo.MVCHijacks {
    public interface IModelFactory {
        object Execute();
    }
}
