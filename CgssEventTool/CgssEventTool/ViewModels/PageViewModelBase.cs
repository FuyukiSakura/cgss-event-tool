using System;
using System.Collections.Generic;
using System.Text;

namespace CgssEventTool.ViewModels
{
    public class PageViewModelBase : BindableBase
    {
        private string _title;

        #region Auto Properties

        /// <summary>
        /// Gets or sets the Title of the current page
        /// </summary>
        public string Title
        {
            get => _title;
            protected set
            {
                if (_title == value) return;
                _title = value;
                OnPropertyChanged();
            }
        }

        #endregion

        
    }
}
