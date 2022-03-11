using System;
using System.Collections.Generic;

namespace KazanSessionOne.Models
{
    public partial class DepartmentLocation
    {
        public DepartmentLocation()
        {
            AssetTransferLogFromDepartmentLocations = new HashSet<AssetTransferLog>();
            AssetTransferLogToDepartmentLocations = new HashSet<AssetTransferLog>();
            Assets = new HashSet<Asset>();
        }

        public long Id { get; set; }
        public long DepartmentId { get; set; }
        public long LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<AssetTransferLog> AssetTransferLogFromDepartmentLocations { get; set; }
        public virtual ICollection<AssetTransferLog> AssetTransferLogToDepartmentLocations { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
