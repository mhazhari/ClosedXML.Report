﻿using ClosedXML.Excel;

namespace ClosedXML.Report.Options
{
    public class HiddenTag: OptionTag
    {
        public override void Execute(ProcessingContext context)
        {
            var xlCell = Cell.GetXlCell(context.Range);
            var cellAddr = xlCell.Address.ToStringRelative(false);

            // worksheet
            if (cellAddr == "A2")
            {
                context.Range.Worksheet.Hide();
            }
            // whole range
            else if (IsSpecialRangeCell(xlCell))
            {
                context.Range.Rows().ForEach(r => r.WorksheetRow().Hide());
            }
        }

        public override byte Priority { get { return 0; } }
    }
}