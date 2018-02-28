using System;
using System.Collections.Generic;
using System.Text;

namespace Receiver.Interfaces
{
    public interface IText
    {
        void highlightText(string str);

        void unHighlightText();

        void write(string str);
    }
}
