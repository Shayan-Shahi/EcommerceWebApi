﻿using Ecommerce.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities;

public class Cart : BaseEntity
{
    #region Fields

    public int UserId { get; set; }

    public int TotalPrice { get; set; }

    public bool IsPay { get; set; }

    public int RefId { get; set; }

    [MaxLength(300)]
    public string Address { get; set; }

    #endregion

    #region Relations

    public User User { get; set; }

    public ICollection<CartDetail> CartDetails { get; set; }
        = new List<CartDetail>();

    #endregion
}
