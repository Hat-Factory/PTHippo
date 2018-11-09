using Pt_Hippo_Mobile.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(ViewCell), typeof(DefaultViewCellRenderer))]

namespace Pt_Hippo_Mobile.iOS.Renderers
{
    public class DefaultViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            
            var cell = base.GetCell(item, reusableCell, tv);
            if (cell != null)
            {
                cell.BackgroundColor = UIColor.Clear;
                if (item.StyleId == "UserInteractionDisabled")
                    cell.UserInteractionEnabled = false;
            }
            return cell;
        }
    }
}
