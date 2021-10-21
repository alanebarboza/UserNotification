using System;

namespace UserNotification.Shared
{
    public abstract class BaseEntity
    {
        public BaseEntity(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public DateTime InsertedDate { get; set; }

        public TChild Copy<TParent, TChild>(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent));
                        break;
                    }
                }
            }

            return child;
        }
    }
}
