using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;

namespace CopyPaste_
{
    public class CustomGridSelectionController : GridSelectionController
    {
        public CustomGridSelectionController(SfDataGrid dataGrid) : base(dataGrid)
        {
            //dataGrid.GetVisualContainer().PointerReleased += CustomGridSelectionController_PointerReleased;
        }

        private void CustomGridSelectionController_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
           // var rowColumnIndex = this.DataGrid.GetVisualContainer().PointToCellRowColumnIndex(e.GetCurrentPoint(this.DataGrid));
           if(this.DataGrid.View != null && this.DataGrid.View.Records.Count ==0)
           {
                this.DataGrid.Focus(Windows.UI.Xaml.FocusState.Programmatic);
           }
        }

        protected override void ProcessKeyDown(KeyRoutedEventArgs args)
        {
            base.ProcessKeyDown(args);
            if(args.Key == Windows.System.VirtualKey.V)
            {
                if (SelectionHelper.CheckControlKeyPressed() && !SelectionHelper.CheckShiftKeyPressed())
                {
                    (this.DataGrid.GridCopyPaste as CustomCopyPaste).PasteTextToRows();
                    args.Handled = true;
                }
            }
        }
    }
}
