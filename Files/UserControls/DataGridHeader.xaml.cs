﻿using Microsoft.Toolkit.Uwp.UI;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Il modello di elemento Controllo utente è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234236

namespace Files.UserControls
{
    public sealed partial class DataGridHeader : UserControl, INotifyPropertyChanged
    {
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }

        private string header;

        public string Header
        {
            get { return header; }
            set
            {
                if (value != header)
                {
                    header = value;
                    NotifyPropertyChanged(nameof(Header));
                }
            }
        }

        private bool canBeSorted = true;

        public bool CanBeSorted
        {
            get { return canBeSorted; }
            set
            {
                if (value != canBeSorted)
                {
                    canBeSorted = value;
                    NotifyPropertyChanged(nameof(CanBeSorted));
                }
            }
        }

        private SortDirection? columnSortOption;

        public SortDirection? ColumnSortOption
        {
            get { return columnSortOption; }
            set
            {
                if (value != columnSortOption)
                {
                    switch (value)
                    {
                        case SortDirection.Ascending:
                            VisualStateManager.GoToState(this, "SortAscending", true);
                            break;

                        case SortDirection.Descending:
                            VisualStateManager.GoToState(this, "SortDescending", true);
                            break;

                        default:
                            VisualStateManager.GoToState(this, "Unsorted", true);
                            break;
                    }
                    columnSortOption = value;
                }
            }
        }

        public DataGridHeader()
        {
            this.InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}