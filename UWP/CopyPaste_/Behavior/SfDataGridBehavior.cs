using Microsoft.Xaml.Interactivity;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPaste_
{
    public class SfDataGridBehavior : Behavior<SfDataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.GridCopyPaste = new CustomCopyPaste(this.AssociatedObject);
            this.AssociatedObject.SelectionController = new CustomGridSelectionController(this.AssociatedObject);
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AssociatedObject.GetVisualContainer().PointerReleased += SfDataGridBehavior_PointerReleased;
        }

        private async void SfDataGridBehavior_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () =>
            {
                if (this.AssociatedObject.View != null && this.AssociatedObject.View.Records.Count == 0)
                {
                    this.AssociatedObject.Focus(Windows.UI.Xaml.FocusState.Programmatic);
                }
            });
        }
    }
}
