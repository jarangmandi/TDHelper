using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDHelper
{
    class AgeUpDown : NumericUpDown
    {
        private static List<decimal> values = new List<decimal>() { 0m, 0.125m, 0.25m, 0.5m, 0.75m, 1m };

        // Override the "Down" button of the NumericUpDown control
        public override void DownButton()
        {
            // Look up the current value in our list
            int index = values.IndexOf(this.Value);
            int newIndex = 0;

            // If we've found it and it's not "0"
            if (index > 0)
            {
                // The new index is simply the previous one in the list
                newIndex = index - 1;

                this.Value = values[newIndex];
            }
            // If isn't not found, then if the value is less than 1
            else if (this.Value < 1)
            {
                // The value needs to be "0"
                this.Value = 0;
            }
            else
            {
                // Otherwise, round the value up to the next highest value and then call the orignal "DownButton" function.
                decimal trunc = Math.Truncate(this.Value);
                if (trunc != this.Value)
                {
                    this.Value = trunc + 1;
                }

                base.DownButton();
            }

        }

        public override void UpButton()
        {
            // Look up the current value in our list
            int index = values.IndexOf(this.Value);
            int newIndex = 0;

            // If we've found it and it's not the last one in the list (1)
            if (index < values.Count -1 && index != -1)
            {
                // The new value is the last one in the list
                newIndex = index + 1;
                this.Value = values[newIndex];
            }
            else
            {
                // Otherwise, use the original "UpButton" function and truncate
                base.UpButton();
                this.Value = Math.Truncate(this.Value);
            }


        }
    }
}
