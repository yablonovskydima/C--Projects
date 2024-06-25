namespace WebAppDataBase.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; set; }
        public SortState PriceSort { get; set; }
        public SortState ProducerSort { get; set; }
        public SortState Current { get; set; }
        public bool Up { get; set; }

        public SortViewModel(SortState sortOrder) 
        {
            NameSort = SortState.NameAsc;
            PriceSort = SortState.PriceAsc;
            ProducerSort = SortState.ProducerAsc;
            Up = true;

            if(sortOrder == SortState.PriceDesc || sortOrder == SortState.NameDesc || sortOrder == SortState.ProducerDesc) 
            {
                Up = false;
            }

            switch (sortOrder) 
            {
                case SortState.NameDesc:
                    Current = NameSort = SortState.NameAsc;
                    break;
                case SortState.PriceAsc:
                    Current = PriceSort = SortState.PriceDesc;
                    break;
                case SortState.PriceDesc:
                    Current = PriceSort = SortState.PriceAsc;
                    break;
                case SortState.ProducerAsc:
                    Current = ProducerSort = SortState.ProducerDesc;
                    break;
                case SortState.ProducerDesc:
                    Current = ProducerSort = SortState.ProducerAsc;
                    break;
                default:
                    Current = NameSort = SortState.NameDesc;
                    break;
            }
        }

    }
}
