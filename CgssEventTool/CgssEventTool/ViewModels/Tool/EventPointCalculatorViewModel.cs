using PageResources = CgssEventTool.Localization.Resources.Layout.EventCalculatorPageResources;

namespace CgssEventTool.ViewModels.Tool
{
    public class EventPointCalculatorViewModel : PageViewModelBase
    {
        private int _playerLevel;
        private int _starTotal;
        private int _eventHours;

        public EventPointCalculatorViewModel()
        {
            Title = PageResources.Title;
        }

        #region Helpers

        private void UpdateResults()
        {
            OnPropertyChanged(nameof(NaturalRecover));
        }

        #endregion

        #region Auto Properties

        #region Input section

        /// <summary>
        /// Gets the total no. of star label text
        /// </summary>
        public string PlayerLevelLabel => PageResources.PlayerLevelLabel;

        /// <summary>
        /// Gets or sets the player level
        /// </summary>
        public int PlayerLevel
        {
            get => _playerLevel;
            set
            {
                _playerLevel = value;
                OnPropertyChanged();
                UpdateResults();
            }
        }

        /// <summary>
        /// Gets the player level label text
        /// </summary>
        public string StarTotalLabel => PageResources.StarTotalLabel;

        /// <summary>
        /// Gets or sets the total no. of star
        /// </summary>
        public int StarTotal
        {
            get => _starTotal;
            set
            {
                _starTotal = value;
                OnPropertyChanged();
                UpdateResults();
            }
        }

        /// <summary>
        /// Gets the event hours label text
        /// </summary>
        public string EventHoursLabel => PageResources.EventHoursLabel;

        /// <summary>
        /// Gets or sets the event hours
        /// </summary>
        public int EventHours
        {
            get => _eventHours;
            set
            {
                _eventHours = value;
                OnPropertyChanged();
                UpdateResults();
            }
        }

        #endregion

        #region Result section

        /// <summary>
        /// Gets natural recover label text
        /// </summary>
        public string NaturalRecoverLabel => PageResources.NaturalRecoverLabel;

        /// <summary>
        /// Gets natural recover no. of stars
        /// </summary>
        public double NaturalRecover => EventHours * 12;

        #endregion

        #region Headers

        public string ResultSectionHeaderText => PageResources.ResultSectionHeader;

        #endregion

        #endregion
    }
}
