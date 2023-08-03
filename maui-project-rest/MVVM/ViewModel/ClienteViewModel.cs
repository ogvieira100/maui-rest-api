﻿using maui_project_rest.Util;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace maui_project_rest.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ClienteViewModel
    {

        public string CPF { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public Guid Id { get; set; }


        public ClienteViewModel()
        {
            
        }
    }
}




