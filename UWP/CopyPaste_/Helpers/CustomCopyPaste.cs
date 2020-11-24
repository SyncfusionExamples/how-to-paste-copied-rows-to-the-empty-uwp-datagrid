using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace CopyPaste_
{
    public class CustomCopyPaste : GridCutCopyPaste
    {
        public CustomCopyPaste(SfDataGrid sfgrid)
            : base(sfgrid)
        {
        }
        
        protected override void PasteToRows(object clipboardrows)
        {
            var copiedRecord = (string[])clipboardrows;
            int copiedrecordscount = copiedRecord.Where(str => str != string.Empty).Count();
            //Based on the clipboard count added the new record for paste
            if (copiedrecordscount > 0)
            {
                for (int i = 0; i < copiedrecordscount; i++)
                {
                    // adding the new record
                    this.dataGrid.View.AddNew();
                    for (int j = 0; j < this.dataGrid.Columns.Count; j++)
                    {
                        var record = copiedRecord[i];
                        string[] splitRecord = Regex.Split(record, @"\t");
                        //Adding the new record by using PasteToCell method by passing the
                        //created data, particular column, and clipboard value
                        this.PasteToCell(this.dataGrid.View.CurrentAddItem, this.dataGrid.Columns[j], splitRecord[j]);
                    }
                    //Added the pasted record in collection
                    this.dataGrid.View.CommitNew();
                }
            }
        }

        public async void PasteTextToRows()
        {
            DataPackageView dataPackage = null;
            dataPackage = Clipboard.GetContent();
            DataPackage package = new DataPackage();
            if (dataPackage.AvailableFormats.Count <= 0)
                return;
            package.SetText(await dataPackage.GetTextAsync());

            if (dataPackage.Contains(StandardDataFormats.Text))
            {
               var clipBoardContent = await dataPackage.GetTextAsync();
 
                if (clipBoardContent == null)
                    return;

                // Split the ClipboardConent to number of rows 
                var copiedRecords = Regex.Split(clipBoardContent.ToString(), @"\r\n");
                //Considered only ExcludeFirstLine while pasting
                if (dataGrid.GridPasteOption.HasFlag(GridPasteOption.ExcludeFirstLine))
                    copiedRecords = copiedRecords.Skip(1).ToArray();
                PasteToRows(copiedRecords);
            }
        }
    }
}
