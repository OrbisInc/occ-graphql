using Occ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Occ.Data
{
    public static class SeedData
    {

        public static void Seed(this DatabaseContext dbContext)
        {

            if (!dbContext.Orders.Any())
            {
                dbContext.Orders.Add(
                new Order
                {
                    DateOrdered = DateTime.Now,
                    DeliveryAddress = "175 Main",
                    DeliveryCity = "Toronto",
                    DeliveryCountry = "Canada",
                    DeliveryPostalCode = "L3A 1V2",
                    Notes = "Blue Order",
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Notes = "Blue Shirt medium",
                            Quantity = 1,
                            Product = new Product
                            {
                                Description ="Blue Shirt",
                                Price = 24.23M,
                                Type = ProductType.Shirt
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Blue Boots Size 12",
                            Quantity = 2,
                            Product = new Product
                            {
                                Description ="Blue Boots",
                                Price = 100.23M,
                                Type = ProductType.Boots
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Blue Shoes Size 8",
                            Quantity = 1,
                            Product = new Product
                            {
                                Description ="Blue Shoes",
                                Price = 123.12M,
                                Type = ProductType.Shoes
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Blue Hat Size Medium",
                            Quantity = 2,
                            Product = new Product
                            {
                                Description ="Blue Hat",
                                Price = 12.87M,
                                Type = ProductType.Hat
                            }
                        }
                    },
                });

                dbContext.Orders.Add(new Order
                {
                    DateOrdered = DateTime.Now,
                    DeliveryAddress = "132 Main",
                    DeliveryCity = "Toronto",
                    DeliveryCountry = "Canada",
                    DeliveryPostalCode = "L3A 1S2",
                    Notes = "Yellow Order",
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Notes = "Yellow Shirt medium",
                            Quantity = 3,
                            Product = new Product
                            {
                                Description = "Yellow Shirt",
                                Price = 21.23M,
                                Type = ProductType.Shirt
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Yellow Boots Size 8",
                            Quantity = 5,
                            Product = new Product
                            {
                                Description = "Yellow Boots",
                                Price = 111.00M,
                                Type = ProductType.Boots
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Yellow Shoes Size 9",
                            Quantity = 4,
                            Product = new Product
                            {
                                Description = "Yellow Shoes",
                                Price = 99.54M,
                                Type = ProductType.Shoes
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Yellow Hat Size Medium",
                            Quantity = 6,
                            Product = new Product
                            {
                                Description = "Yellow Hat",
                                Price = 8.43M,
                                Type = ProductType.Hat
                            }
                        }
                    }
                });

                dbContext.Orders.Add(new Order
                {
                    DateOrdered = DateTime.Now,
                    DeliveryAddress = "12 Main",
                    DeliveryCity = "Toronto",
                    DeliveryCountry = "Canada",
                    DeliveryPostalCode = "M5W 1V3",
                    Notes = "Pink Order",
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Notes = "Pink Shirt xlarge",
                            Quantity = 2,
                            Product = new Product
                            {
                                Description = "Pink Shirt",
                                Price = 15.14M,
                                Type = ProductType.Shirt
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Pink Boots Size 7",
                            Quantity = 5,
                            Product = new Product
                            {
                                Description = "Pink Boots",
                                Price = 93.00M,
                                Type = ProductType.Boots
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Pink Shoes Size 3",
                            Quantity = 4,
                            Product = new Product
                            {
                                Description = "Pink Shoes",
                                Price = 99.54M,
                                Type = ProductType.Shoes
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Pink Hat Size Large",
                            Quantity = 6,
                            Product = new Product
                            {
                                Description = "Pink Hat",
                                Price = 12.19M,
                                Type = ProductType.Hat
                            }
                        }
                    }
                });


                dbContext.Orders.Add(new Order
                {
                    DateOrdered = DateTime.Now,
                    DeliveryAddress = "12 Main",
                    DeliveryCity = "Toronto",
                    DeliveryCountry = "Canada",
                    DeliveryPostalCode = "M5W 1V3",
                    Notes = "Orange Order",
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Notes = "Orange Shirt large",
                            Quantity = 2,
                            Product = new Product
                            {
                                Description = "Orange Shirt",
                                Price = 12.14M,
                                Type = ProductType.Shirt
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Orange Boots Size 12",
                            Quantity = 8,
                            Product = new Product
                            {
                                Description = "Orange Boots",
                                Price = 86.39M,
                                Type = ProductType.Boots
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Orange Shoes Size 3",
                            Quantity = 4,
                            Product = new Product
                            {
                                Description = "Orange Shoes",
                                Price = 99.54M,
                                Type = ProductType.Shoes
                            }
                        },
                        new OrderItem
                        {
                            Notes = "Orange Hat Size Large",
                            Quantity = 6,
                            Product = new Product
                            {
                                Description = "Orange Hat",
                                Price = 12.19M,
                                Type = ProductType.Hat
                            }
                        }
                    }
                });



                dbContext.SaveChanges();
            }

        }
    }
}
