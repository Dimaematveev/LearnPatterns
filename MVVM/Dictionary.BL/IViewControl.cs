﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Dictionary.BL.ViewDictionary
{
    public interface IViewControl
    {
        UserControl GetEditAddUserControl();
    }
}
