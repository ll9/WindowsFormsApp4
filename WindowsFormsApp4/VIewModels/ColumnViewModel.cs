using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.ViewModels
{
    class SqlCsharpType
    {
        public SqlCsharpType(string sqlType, Type csharpType)
        {
            SqlType = sqlType;
            CsharpType = csharpType;
        }

        public string SqlType { get; set; }
        public Type CsharpType { get; set; }
    }

    class ColumnViewModel: INotifyPropertyChanged
    {
        private string _name;
        public string Name { get => _name; set => SetField(ref _name, value); }
        private SqlCsharpType _sqlType;
        public SqlCsharpType SqlType { get => _sqlType; set => SetField(ref _sqlType, value); }

        public bool IsValid { get => !string.IsNullOrEmpty(Name); }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //C# 6 null-safe operator. No need to check for event listeners
            //If there are no listeners, this will be a noop
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // C# 5 - CallMemberName means we don't need to pass the property's name
        protected bool SetField<T>(ref T field, T value,
        [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
