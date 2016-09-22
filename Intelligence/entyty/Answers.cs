namespace Intelligence.entyty
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Answers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string text { get; set; }

        public bool is_true { get; set; }

        public int question_id { get; set; }

        public virtual Questions Questions { get; set; }
    }
}
