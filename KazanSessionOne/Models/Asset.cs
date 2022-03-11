using System;
using System.Collections.Generic;

namespace KazanSessionOne.Models
{
    public partial class Asset
    {
        public Asset()
        {
            AssetPhotos = new HashSet<AssetPhoto>();
            AssetTransferLogs = new HashSet<AssetTransferLog>();
        }

        public long Id { get; set; }
        public string AssetSn { get; set; } = null!;
        public string AssetName { get; set; } = null!;
        public long DepartmentLocationId { get; set; }
        public long EmployeeId { get; set; }
        public long AssetGroupId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? WarrantyDate { get; set; }

        public virtual AssetGroup AssetGroup { get; set; } = null!;
        public virtual DepartmentLocation DepartmentLocation { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<AssetPhoto> AssetPhotos { get; set; }
        public virtual ICollection<AssetTransferLog> AssetTransferLogs { get; set; }
    }
}
