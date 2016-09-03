using System.Windows.Forms;

namespace TableConverter
{
    using System;
    using System.Collections.Generic;

    public partial class FrameSelecting : Form
    {
        private List<int> selectedFrames;

        public FrameSelecting()
        {
            InitializeComponent();
            this.selectedFrames = new List<int>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Location = Owner.Location;
        }

        public IEnumerable<int> SelectedFrames { get { return this.selectedFrames; } }

        private void UserInputForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void frame1Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(1);
        }

        private void frame2Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(2);
        }

        private void frame3Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(3);
        }

        private void frame4Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(4);
        }

        private void frame5Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(5);
        }

        private void frame6Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(6);
        }

        private void frame7Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(7);
        }

        private void frame8Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(8);
        }

        private void Fframe9Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(9);
        }

        private void frame10Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(10);
        }

        private void frame11Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(11);
        }

        private void frame12Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(12);
        }

        private void frame13Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(13);
        }

        private void frame14Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(14);
        }

        private void frame15Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(15);
        }

        private void frame16Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(16);
        }

        private void frame17Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(17);
        }

        private void frame18Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(18);
        }

        private void frame19Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(19);
        }

        private void frame20Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(20);
        }

        private void frame21Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(21);
        }

        private void frame22Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(22);
        }

        private void frame23Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(23);
        }

        private void frame24Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(24);
        }

        private void frame25Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(25);
        }

        private void frame26Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(26);
        }

        private void frame27Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(27);
        }

        private void frame28Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedFrames.Add(28);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
