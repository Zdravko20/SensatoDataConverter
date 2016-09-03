namespace TableConverter
{
    using System.IO;
    using Constants;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using IO;
    using TableConvertors;

    public partial class SensatoTableConverter : Form
    {
        private const string RequiredFileExtention = "txt";
        private const string ResultFileExtention = "xlsx";

        private string dropLocationText = Messages.DragFileMessage;
        private FileInputReader fileReader = new FileInputReader();
        private ExcelTableConverter excelTableConverter = new ExcelTableConverter();
        private InputValidator checker = new InputValidator();
        private bool isDropped = false;
        private bool isFrameSelected = false;

        //FileInfo
        private int[] selectedFrames = null;
        private string filePath = null;
        private string newfilePath = null;
        private string[] allLines = null;
        private string[] validLines = null;

        public SensatoTableConverter()
        {
            InitializeComponent();
        }

        private void TableConverter_Paint(object sender, PaintEventArgs e)
        {
            if (!this.isDropped)
            {
                this.SelectFramesButton.Enabled = false;
                this.ConvertButton.Enabled = false;
            }
            else if (this.isDropped && !this.isFrameSelected)
            {
                this.SelectFramesButton.Enabled = true;
            }
            else
            {
                this.SelectFramesButton.Enabled = true;
                this.ConvertButton.Enabled = true;
            }
        }

        private void DropLocation_Paint(object sender, PaintEventArgs e)
        {
            using (SolidBrush br = new SolidBrush(Color.Black))
            {
                Font font = new Font("Arial", 18);
                e.Graphics.DrawString(dropLocationText, font, br, this.DropLocation.Location.X * 3,
                    this.DropLocation.Location.Y * 2);
            }
        }

        private void DropLocation_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DropLocation_DragDrop(object sender, DragEventArgs e)
        {
            if (!this.CheckIfFileIsInCorrectFormat(e.Data))
            {
                this.dropLocationText = Messages.NotSupportedFileMessage;
                this.Refresh();
                return;
            }

            this.dropLocationText = string.Format(Messages.FileLoadedMessage);
            this.isDropped = true;
            this.Refresh();

            this.filePath = this.GetFilePath(e.Data);
            this.newfilePath = filePath.Replace(RequiredFileExtention, ResultFileExtention);

            //Setting the file path to the file that the we should read from
            this.fileReader.FilePath = this.filePath;

            this.allLines = this.fileReader.ReadInput();
            this.validLines = this.checker.ParseValideLines(allLines);

        }

        private bool CheckIfFileIsInCorrectFormat(IDataObject fileDataObject)
        {
            string[] data = (string[])fileDataObject.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                string fileName = data[0];
                string extention = Path.GetExtension(fileName);
                if (extention.ToLower() != $".{RequiredFileExtention}")
                {
                    return false;
                }
            }

            return true;
        }

        private string GetFilePath(IDataObject fileDataObject)
        {
            string[] data = (string[])fileDataObject.GetData(DataFormats.FileDrop);
            string resultFilePath = data[0];

            return resultFilePath;
        }

        private void SelectFramesButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Point newLocationFromSecondForm;
            using (FrameSelecting userInputForm = new FrameSelecting())
            {
                userInputForm.ShowDialog(this);
                this.selectedFrames = userInputForm.SelectedFrames.ToArray();
                newLocationFromSecondForm = userInputForm.Location;
            }

            this.Location = newLocationFromSecondForm;
            this.Visible = true;
            if (this.selectedFrames != null && this.selectedFrames.Length > 0)
            {
                this.isFrameSelected = true;
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.excelTableConverter.ConvertToTable(validLines, newfilePath, this.selectedFrames);
            }
            catch (IndexOutOfRangeException)
            {
                this.dropLocationText = Messages.InvalidNumberOfFramesSelected;
                this.Refresh();
                return;
            }
            //catch (ArgumentException ae)
            //{
            //    this.dropLocationText = ae.Message;
            //    this.Refresh();
            //    return;
            //}

            this.dropLocationText = Messages.FileSuccessfullyConverted;
            this.Refresh();
        }
    }
}
