using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Shmzh.Windows.Forms
{
    public class ToolStripDateTimePicker : ToolStripControlHost
    {
        // Call the base constructor passing in a DateTimePicker instance.
        public ToolStripDateTimePicker() : base(new DateTimePicker()) 
        {

        }
        public DateTimePicker DateTimePickerControl
        {
            get
            {
                return Control as DateTimePicker;
            }
        }

        // Expose the DateTimePicker.Value as a property.
        public DateTime Value
        {
            get
            {
                return DateTimePickerControl.Value;
            }
            set { DateTimePickerControl.Value = value; }
        }

        // Subscribe and unsubscribe the control events you wish to expose.
        protected override void OnSubscribeControlEvents(Control c)
        {
            base.OnSubscribeControlEvents(c);
            DateTimePicker DateTimePickerControl = (DateTimePicker)c;

            // Add the event.
            DateTimePickerControl.ValueChanged += new EventHandler(OnValueChanged);
        }

        protected override void OnUnsubscribeControlEvents(Control c)
        {
            // Call the base method so the basic events are unsubscribed.
            base.OnUnsubscribeControlEvents(c);

            // Cast the control to a DateTimePicker control.
            DateTimePicker DateTimePickerControl = (DateTimePicker)c;

            // Remove the event.
            DateTimePickerControl.ValueChanged -= new EventHandler(OnValueChanged);
        }

        // Declare the ValueChanged event.
        public event EventHandler ValueChanged;

        // Raise the ValueChanged event.
        private void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }
        }
    }
}
