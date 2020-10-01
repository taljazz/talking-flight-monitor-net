using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblCruisingTables
    {
        public string CruiseTableIdentifier { get; set; }
        public long? Seqno { get; set; }
        public double? CourseFrom { get; set; }
        public double? CourseTo { get; set; }
        public string MagTrue { get; set; }
        public long? CruiseLevelFrom1 { get; set; }
        public long? VerticalSeparation1 { get; set; }
        public long? CruiseLevelTo1 { get; set; }
        public long? CruiseLevelFrom2 { get; set; }
        public long? VerticalSeparation2 { get; set; }
        public long? CruiseLevelTo2 { get; set; }
        public long? CruiseLevelFrom3 { get; set; }
        public long? VerticalSeparation3 { get; set; }
        public long? CruiseLevelTo3 { get; set; }
        public long? CruiseLevelFrom4 { get; set; }
        public long? VerticalSeparation4 { get; set; }
        public long? CruiseLevelTo4 { get; set; }
    }
}
