using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ForBiolytic.Annotations;

namespace ForBiolytic
{
    public class DataContext : IDataContext
    {

        public DataContext()
        {
            this.Entries = new ObservableCollection<string>();
            Entries.Add("adf");
            RemoveItem = new Command((o) =>
                {
                    Entries.Remove(SelectedEntry);
                }, 
                parameter => true);

            AddItem = new Command((o) =>
                {
                    Entries.Add(Guid.NewGuid().ToString());
                }, 
                parameter => true);

        }

        public string SelectedEntry
        {
            get { return _selectedEntry; }
            set
            {
                _selectedEntry = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> _entries;
        private ICommand _removeItem;
        private ICommand _addItem;
        private string _selectedEntry;

        public ICommand RemoveItem
        {
            get { return _removeItem; }
            set
            {
                _removeItem = value;
                OnPropertyChanged();

            }
        }

        public ICommand AddItem
        {
            get { return _addItem; }
            set
            {
                _addItem = value;
                OnPropertyChanged();

            }
        }

        public ObservableCollection<string> Entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}