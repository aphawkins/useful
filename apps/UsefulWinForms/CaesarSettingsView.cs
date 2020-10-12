﻿// <copyright file="CaesarSettingsView.cs" company="APH Software">
// Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>

namespace UsefulWinForms
{
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using Useful.Security.Cryptography.UI.Controllers;
    using Useful.Security.Cryptography.UI.ViewModels;
    using Useful.Security.Cryptography.UI.Views;

    public partial class CaesarSettingsView : UserControl, ICipherSettingsView
    {
        private SettingsController? _controller;

        public CaesarSettingsView()
        {
            InitializeComponent();

            comboRightShift.SelectionChangeCommitted += (sender, e) => ComboChanged();
        }

        public void SetController(IController controller) => _controller = (SettingsController)controller;

        public void Initialize()
        {
            CaesarSettingsViewModel settings = (CaesarSettingsViewModel)_controller!.Settings;
            comboRightShift.Items.AddRange(Enumerable.Range(0, 26).Cast<object>().ToArray());
            comboRightShift.SelectedIndex = settings.RightShift;
        }

        private void ComboChanged() => ((CaesarSettingsViewModel)_controller!.Settings).RightShift = (int)comboRightShift.SelectedItem;
    }
}