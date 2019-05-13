using Dnc.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dnc.AppServices
{
    public class QueryParameters
        : INotifyPropertyChanged
    {
        #region Private const members.
        private const int DefaultPageSize = 10;
        private const int DefaultMaxPageSize = 100;
        #endregion

        private int _pageIndex;

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value >= 1 ? value : 1;
        }

        private int _pageSize = DefaultPageSize;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value >= DefaultPageSize ? value : DefaultPageSize;
        }

        private string _orderBy;

        public string OrderBy
        {
            get => _orderBy;
            set => _orderBy = string.IsNullOrEmpty(value) ? nameof(Entity.Id) : value;
        }

        public string Fields { get; set; }

        #region PropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
