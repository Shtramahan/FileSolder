using FileManager.Models;
using FileManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FileSolder.ModelView
{
    public class ViewModel
    {
        public ViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #region GoToDesktop
        private RelayCommand _goToCommand;
        public RelayCommand GoToCommand => _goToCommand ??= new RelayCommand(GoTo, param => true);
        public void GoTo(object pathParameter)
        {
            string path = pathParameter?.ToString();

            if(path != Path)
            {
                Path = path;
            }

            if (String.IsNullOrEmpty(path))
            {
                Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            EnviromentProvider.TryGetItemsInDirectory(Path, out var items);
            FileCollection = items;
        }

        private string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string Path
        {
            get 
            { 
                return _path;
            }
            set 
            {               
                _path = value;
                OnPropertyChanged("Path");
            }
        }
        #endregion

        #region Item
        private ObservableCollection<Item> _fileCollection;
        public ObservableCollection<Item> FileCollection
        {
            get 
            { 
                if (_fileCollection == null) 
                {
                    EnviromentProvider.TryGetItemsInDirectory(Path, out var items);
                    _fileCollection = items;
                }

                return _fileCollection;
            }

            set
            {
                _fileCollection = value;
                OnPropertyChanged("FileCollection");
            }
        }
        #endregion

        #region PropertiesList
        //private string _folder = new
        #endregion
    }
}
