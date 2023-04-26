using System;
using System.Collections.Generic;

#nullable disable

namespace RollOffApi
{
    public partial class FeedbackForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalGrade { get; set; }
        public string PrimarySkill { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Practice { get; set; }
        public string RollOffEndDate { get; set; }
        public string ReasonForRollOff { get; set; }
        public string ThisReleaseNeedsBackfillIsBackfilled { get; set; }
        public string PerformanceIssue { get; set; }
        public string Resigned { get; set; }
        public string UnderProbation { get; set; }
        public string LongLeave { get; set; }
        public string TechnicalSkill { get; set; }
        public string Communication { get; set; }
        public string RoleCompetencies { get; set; }
        public string Remarks { get; set; }
        public string RelevantExperienceYears { get; set; }
        public string LeaveType { get; set; }
        public string OtherReasons { get; set; }
    }
}
