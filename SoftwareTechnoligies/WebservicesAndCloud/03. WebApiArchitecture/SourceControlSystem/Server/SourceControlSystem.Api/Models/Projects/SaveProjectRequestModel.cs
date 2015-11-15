namespace SourceControlSystem.Api.Models.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using Common.Constants;

    public class SaveProjectRequestModel
    {
        [Required]
        [MaxLength(ValidationConstants.MaxProjectNameLength)]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.MaxProjectDescriptionLength)]
        public string  Description { get; set; }

        public bool Private { get; set; }
    }
}