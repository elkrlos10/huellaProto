﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace huellaProto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class huellaProto : ContentPage
    {
        public huellaProto()
        {
            InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}