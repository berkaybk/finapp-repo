﻿using System.ComponentModel.DataAnnotations;

namespace FinApp.UI.Models.ViewModels
{
    public class UpdatePartnerViewModel:AddPartnerViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid Id { get; set; }
        public int RecordStatus { get; set; }
    }
}
