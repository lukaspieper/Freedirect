﻿using System;
using Application.Main.StartPoint;

namespace Application.Main
{
    public partial class App
    {
        public App()
        {
            var factory = new StartPointFactory();
            var startPoint = factory.GetStartPoint();
            startPoint?.Start();
        }

        [STAThread]
        private static void Main()
        {
            var application = new App();
            application.InitializeComponent();
            application.Run();
        }
    }
}