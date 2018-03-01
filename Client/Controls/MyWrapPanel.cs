using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client.Controls
{
    public class MyWrapPanel : WrapPanel
    {
        protected override Size MeasureOverride(Size constraint)
        {
            Size curLineSize = new Size();
            Size panelSize = new Size(constraint.Width, 0);
            UIElementCollection children = base.InternalChildren;

            for (int i = 0; i < children.Count; i++)
            {
                UIElement child = children[i] as UIElement;

                child.Measure(constraint);
                Size sz = child.DesiredSize;
                if (curLineSize.Width + sz.Width > constraint.Width) // new line
                {
                    panelSize.Width = Math.Max(curLineSize.Width, panelSize.Width);
                    panelSize.Height += curLineSize.Height;
                    if (i > 0)
                    {
                        // change width of prev control here
                        var lastChildInRow = children[i - 1] as Control;
                        lastChildInRow.Width = lastChildInRow.ActualWidth + panelSize.Width - curLineSize.Width;
                    }
                    curLineSize = sz;
                }
                else
                {
                    curLineSize.Width += sz.Width;
                    curLineSize.Height = Math.Max(sz.Height, curLineSize.Height);
                }
            }
            panelSize.Width = Math.Max(curLineSize.Width, panelSize.Width);
            panelSize.Height += curLineSize.Height;

            return panelSize;
        }
    }
}
