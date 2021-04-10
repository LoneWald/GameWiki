using System;
using System.Collections.Generic;
using System.Text;

namespace GameWiki
{
    public interface ToastMessage
    {
        void LongTime(string message);
        void ShortTime(string message);

    }
}
