﻿using WebStore.DomainModels.Interfaces;

namespace WebStore.DomainModels.Entities.Classes.Base
{
    public class NamedEntity : BaseEntity, INamedEntity
    {

        public string Name { get; set; }
    }
}