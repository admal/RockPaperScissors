using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Frontends.OutputProviders
{
    public interface IOutputProvider
    {
        void Write(string message = "");
    }
}
