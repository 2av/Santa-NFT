using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Santa_NFT.Models
{
    public class FileManager:Base   
    {
        public int FileManagerId { get; set; }

        public string FileGuid { get; set; }

        public string FileName { get; set; }

        public double? FileSize { get; set; }
        public string FileExtension { get; set; }

        public string UploadFrom { get; set; }

        public string FilePath { get; set; }

        public int? UploadedBy { get; set; }

        public DateTime? UploadedDate { get; set; }
    }
}