using CgssEventTool.BusinessLogicLayer;
using PageResources = CgssEventTool.Localization.Resources.Layout.EventCalculatorPageResources;

namespace CgssEventTool.ViewModels.Tool
{
    public class EventPointCalculatorViewModel : PageViewModelBase
    {
        private const int SingleStaminaPerPlay = 19;
        private const int SingleCollectionPerPlay = 53;

        private int _playerLevel = 200;
        private int _starTotal = 1000;
        private int _eventHours = 174;

        public EventPointCalculatorViewModel()
        {
            Title = PageResources.Title;
        }

        #region Helpers

        /// <summary>
        /// Updates the results
        /// </summary>
        private void UpdateResults()
        {
            OnPropertyChanged(nameof(NaturalRecover));
            OnPropertyChanged(nameof(GamesOfMultiplierOne));
            OnPropertyChanged(nameof(GamesOfMultiplierTwo));
            OnPropertyChanged(nameof(CollectedItemNo));
            OnPropertyChanged(nameof(CollectedPointsFromItem));
            OnPropertyChanged(nameof(CollectedPointsUsingItem));
            OnPropertyChanged(nameof(TotalPoints));
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
        public long NaturalRecover => EventHours * 12;

        /// <summary>
        /// Gets round of games of multiplier 1 label text
        /// </summary>
        public string MultiplierOneLabel => PageResources.MultiplierOneLabel;

        /// <summary>
        /// Gets the number of games required using 19 stamina
        /// </summary>
        public double GamesOfMultiplierOne => CgssCollect.TotalStaminaToPlay(
            StarTotal,
            PlayerLevel,
            NaturalRecover,
            SingleStaminaPerPlay
        );

        /// <summary>
        /// Gets round of games of multiplier 1 label text
        /// </summary>
        public string MultiplierTwoLabel => PageResources.MultiplierTwoLabel;

        /// <summary>
        /// Gets the number of games required using 38 stamina
        /// </summary>
        public double GamesOfMultiplierTwo => GamesOfMultiplierOne / 2;

        /// <summary>
        /// Gets no. of collected items label text
        /// </summary>
        public string CollectedItemLabel => PageResources.CollectedItemLabel;

        /// <summary>
        /// Gets no. of collected items
        /// </summary>
        public double CollectedItemNo => CgssCollect.TotalNumCollect(
            StarTotal,
            PlayerLevel,
            NaturalRecover,
            SingleStaminaPerPlay,
            SingleCollectionPerPlay);

        /// <summary>
        /// Gets points from item label
        /// </summary>
        public string CollectedPointsFromItemLabel => PageResources.CollectedPointsFromItemLabel;

        /// <summary>
        /// Gets point from item
        /// </summary>
        public double CollectedPointsFromItem => CollectedItemNo / 2f;

        /// <summary>
        /// Gets points from using item label
        /// </summary>
        public string CollectedPointsUsingItemLabel => PageResources.CollectedPointsUsingItemLabel;

        /// <summary>
        /// Gets points from using item
        /// </summary>
        public double CollectedPointsUsingItem => CollectedItemNo / 150f * 320f;

        /// <summary>
        /// Gets total points label
        /// </summary>
        public string TotalPointsLabel => PageResources.TotalPointsLabel;

        /// <summary>
        /// Gets total points collected
        /// </summary>
        public double TotalPoints => CollectedPointsFromItem + CollectedPointsUsingItem;


        #endregion

        #region Headers

        public string ResultSectionHeaderText => PageResources.ResultSectionHeader;

        public string CollectedItemHeaderText => PageResources.CollectedItemHeader;

        public string SummeryHeaderText => PageResources.SummaryHeader;

        #endregion

        #endregion
    }
}
