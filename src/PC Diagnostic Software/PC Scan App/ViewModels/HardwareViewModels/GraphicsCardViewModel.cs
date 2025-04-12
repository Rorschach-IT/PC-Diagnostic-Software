using PC_Scan_App.Models.HardwareModels;
using PC_Scan_App.MVVM;

namespace PC_Scan_App.ViewModels.HardwareViewModels
{
    public class GraphicsCardViewModel : ViewModelBase
    {
        private List<GraphicsCardModel> _graphicsCard;
        public List<GraphicsCardModel> GraphicsCardModel
        {
            get => _graphicsCard;
            set
            {
                _graphicsCard = value;
                OnPropertyChanged(nameof(GraphicsCardModel));
            }
        }

        public GraphicsCardViewModel()
        {
            _graphicsCard = [];
        }
        public void LoadGraphicsCardData()
        {
            GraphicsCardModel = Functions.HardwareDataFetcher.GetGraphicsCardInfo();
        }
    }
}
