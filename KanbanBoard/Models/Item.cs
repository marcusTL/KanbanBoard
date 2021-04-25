using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KanbanBoard.Models
{
    [Table("ItemsInfo")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [ForeignKey("Id")]
        public virtual IdentityUser User { get; set; }

        public string UserId { get; set; }


        public string Title { get; set; }

        public string Description { get; set; }
        
        

        public BoardState BoardState { get; set; }

       

    }
}
