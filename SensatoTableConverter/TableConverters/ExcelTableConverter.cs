namespace TableConverter.TableConvertors
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using Constants;
    using Contracts;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    public class ExcelTableConverter : ITableConverter
    {
        private const int NumberOfSensors = 3;
        private const int StartingRow = 3;
        private const int StartingCol = 3;
        private const int NumberOfFrames = 28;
        private const int DateColumnWidth = 10;
        private const string splitPattern = ",---,|---";

        private int dateCol;
        private int timeCol;
        private int averageCol;
        private int outsideTempCol;

        Dictionary<int, int> positionOfFrame = new Dictionary<int, int>();

        public void ConvertToTable(string[] validFileLines, string filePath, int[] selectedFrames)
        {
            var file = new FileInfo(filePath);

            using (ExcelPackage xlPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("TestSheet");
                worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                this.CreateHeader(worksheet);
                this.FillTable(worksheet, validFileLines, selectedFrames);

                xlPackage.SaveAs(file);
            }
        }

        private void FillTable(ExcelWorksheet worksheet, string[] validFileLines, int[] selectedFrames)
        {
            int newStartingRow = StartingRow + 2;

            for (int i = 0; i < validFileLines.Length; i++)
            {
                int currRow = newStartingRow;
                int currSelectedFrameIndex = 0;
                int currentAverageTemp = 0;

                string[] beeTempInfo = Regex.Split(validFileLines[i], splitPattern);

                for (int j = 0; j < beeTempInfo.Length - 1; j++)
                {
                    if (!string.IsNullOrEmpty(beeTempInfo[j]))
                    {
                        string[] splittedBeeTempInfo = beeTempInfo[j].Split(',');
                        if (splittedBeeTempInfo.Length > 1)
                        {
                            int currSensor = NumberOfSensors;
                            for (int k = 0; k < splittedBeeTempInfo.Length; k++)
                            {
                                int currentCol = this.positionOfFrame[selectedFrames[currSelectedFrameIndex]];

                                worksheet.Cells[currRow, StartingCol].Value =
                                    string.Format(TableConstants.SensorNumber, currSensor);
                                worksheet.Cells[currRow, currentCol].Value = splittedBeeTempInfo[k];

                                currentAverageTemp += int.Parse(splittedBeeTempInfo[k]);
                                currRow++;
                                currSensor--;
                            }
                            
                            currSelectedFrameIndex++;
                            currRow = newStartingRow;
                        }
                        else if (splittedBeeTempInfo.Length == 1)
                        {
                            worksheet.Cells[currRow + 1, this.outsideTempCol]
                                .Value = splittedBeeTempInfo[0];
                        }
                    }
                }

                worksheet.Cells[currRow + 1, this.averageCol]
                     .Value = currentAverageTemp / (NumberOfSensors * selectedFrames.Length);
                worksheet.Cells[currRow + 1, this.outsideTempCol]
                    .Value = TableConstants.NoOutsideTempValue;

                worksheet.Cells[currRow + 1, this.timeCol].Value = beeTempInfo[beeTempInfo.Length - 1].Split(',')[0];
                worksheet.Cells[currRow , this.dateCol].Value = beeTempInfo[beeTempInfo.Length - 1].Split(',')[1];
                worksheet.Cells[currRow + 1, this.dateCol].Value = beeTempInfo[beeTempInfo.Length - 1].Split(',')[1];
                worksheet.Cells[currRow + 2, this.dateCol].Value = beeTempInfo[beeTempInfo.Length - 1].Split(',')[1];

                newStartingRow += NumberOfSensors;                
            }
        }

        private void CreateHeader(ExcelWorksheet worksheet)
        {
            worksheet.Row(StartingRow).Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            var range = worksheet.Cells[StartingRow, StartingCol, StartingRow, StartingCol + NumberOfFrames + 5];
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            worksheet.Row(StartingRow).Height = 40;

            worksheet.Cells[StartingRow, StartingCol].Value = TableConstants.FrameNumberHeader;
            int frameCounter = 1;
            var lastUsedCol = StartingCol + NumberOfFrames;
            for (int i = lastUsedCol; i > StartingCol; i--)
            {
                worksheet.Cells[StartingRow, i].Value = frameCounter;
                if (!this.positionOfFrame.ContainsKey(frameCounter))
                {
                    this.positionOfFrame.Add(frameCounter, i);
                }

                frameCounter++;
            }

            lastUsedCol += 1;
            worksheet.Cells[StartingRow, ++lastUsedCol].Value = TableConstants.UnderTheRoofTempHeader;
            this.averageCol = lastUsedCol;                      
            worksheet.Cells[StartingRow, ++lastUsedCol].Value = TableConstants.OutsideTempHeader;
            this.outsideTempCol = lastUsedCol;                  
            worksheet.Cells[StartingRow, ++lastUsedCol].Value = TableConstants.TimeHeader;
            this.timeCol = lastUsedCol;                         
            worksheet.Cells[StartingRow, ++lastUsedCol].Value = TableConstants.DateHeader;
            this.dateCol = lastUsedCol;

            worksheet.Column(this.dateCol).Width = DateColumnWidth;
        }
    }
}
