﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class data : IDisposable
    {
        public static int penColor;
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
